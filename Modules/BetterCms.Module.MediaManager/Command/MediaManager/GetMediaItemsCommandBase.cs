﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using BetterCms.Core.Api.DataContracts;
using BetterCms.Core.DataAccess.DataContext;
using BetterCms.Core.Mvc.Commands;
using BetterCms.Module.MediaManager.Content.Resources;
using BetterCms.Module.MediaManager.Models;
using BetterCms.Module.MediaManager.ViewModels.MediaManager;
using BetterCms.Module.Root.Mvc;
using BetterCms.Module.Root.Mvc.Grids.Extensions;

using MvcContrib.Sorting;

namespace BetterCms.Module.MediaManager.Command.MediaManager
{
    public abstract class GetMediaItemsCommandBase<TEntity> : CommandBase, ICommand<MediaManagerViewModel, MediaManagerItemsViewModel>
        where TEntity: MediaFile
    {
        /// <summary>
        /// Gets the type of the current media items.
        /// </summary>
        /// <value>
        /// The type of the current media items.
        /// </value>
        protected abstract MediaType MediaType { get; }

        /// <summary>
        /// Executes this command.
        /// </summary>
        /// <param name="request">A filter to search for specific media items/folders.</param>
        /// <returns>A list of tags.</returns>
        public MediaManagerItemsViewModel Execute(MediaManagerViewModel request)
        {
            request.SetDefaultSortingOptions("Title");

            var items = GetAllItemsList(request);
            var model = new MediaManagerItemsViewModel(items.Items, request, items.TotalCount);
            model.Path = LoadMediaFolder(request);

            return model;
        }

        /// <summary>
        /// Loads the media folder.
        /// </summary>
        /// <returns>Media folder view model</returns>
        private MediaPathViewModel LoadMediaFolder(MediaManagerViewModel request)
        {
            var emptyFolderViewModel = new MediaFolderViewModel { Id = Guid.Empty, Type = MediaType };
            var model = new MediaPathViewModel
                            {
                                CurrentFolder = emptyFolderViewModel
                            };
            var folders = new List<MediaFolderViewModel> { emptyFolderViewModel };

            if (!request.CurrentFolderId.HasDefaultValue())
            {
                var mediaFolder = Repository.FirstOrDefault<MediaFolder>(e => e.Id == request.CurrentFolderId && e.Original == null);
                model.CurrentFolder = mediaFolder != null
                    ? new MediaFolderViewModel
                        {
                            Id = mediaFolder.Id,
                            Name = mediaFolder.Title,
                            Version = mediaFolder.Version,
                            Type = mediaFolder.Type,
                            ParentFolderId = mediaFolder.Folder != null ? mediaFolder.Folder.Id : Guid.Empty
                        }
                    : new MediaFolderViewModel();
                while (mediaFolder != null)
                {
                    folders.Insert(
                        1,
                        new MediaFolderViewModel
                            {
                                Id = mediaFolder.Id,
                                Name = mediaFolder.Title,
                                Type = mediaFolder.Type,
                                ParentFolderId = mediaFolder.Folder != null ? mediaFolder.Folder.Id : Guid.Empty
                            });
                    mediaFolder = mediaFolder.Folder;
                }
            }

            model.Folders = folders;
            return model;
        }

        /// <summary>
        /// Gets all items list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Media items list</returns>
        private DataListResponse<MediaViewModel> GetAllItemsList(MediaManagerViewModel request)
        {
            var query = Repository
                .AsQueryable<Media>()
                .Where(m => !m.IsDeleted
                    && m.Original == null
                    && m.Type == MediaType
                    && (m is MediaFolder || m is TEntity && !((TEntity)m).IsTemporary));

            if (!request.IncludeArchivedItems)
            {
                query = query.Where(m => !m.IsArchived);
            }

            if (request.Tags != null)
            {
                foreach (var tagKeyValue in request.Tags)
                {
                    var id = tagKeyValue.Key.ToGuidOrDefault();
                    query = query.Where(m => m.MediaTags.Any(mt => mt.Tag.Id == id));
                }
            }

            if (!string.IsNullOrWhiteSpace(request.SearchQuery) || request.Tags != null)
            {
                var searchQuery = string.Format("%{0}%", request.SearchQuery);
                query = query.Where(m => m.Title.Contains(searchQuery) || m.Description.Contains(searchQuery));

                var result = new List<Media>();
                var mediaList = query.ToList();

                foreach (var media in mediaList)
                {
                    if (IsChild(media, request.CurrentFolderId, request.IncludeArchivedItems))
                    {
                        result.Add(media);
                    }
                }

                return ToResponse(request, result.AsQueryable());
            }

            if (!request.CurrentFolderId.HasDefaultValue())
            {
                query = query.Where(m => m.Folder.Id == request.CurrentFolderId);
            }
            else
            {
                query = query.Where(m => m.Folder == null);
            }

            return ToResponse(request, query);
        }

        private static bool IsChild(Media media, Guid currentFolderId, bool includeArchivedItems)
        {
            if (media == null)
            {
                return false;
            }

            if (media.IsDeleted || (media.Folder != null && media.Folder.IsDeleted))
            {
                return false;
            }

            if (!includeArchivedItems && (media.IsArchived || (media.Folder != null && media.Folder.IsArchived)))
            {
                return false;
            }

            if (currentFolderId.HasDefaultValue())
            {
                return true;
            }

            if (media.Folder != null && !media.Folder.IsDeleted && media.Folder.Id == currentFolderId)
            {
                return true;
            }

            return IsChild(media.Folder, currentFolderId, includeArchivedItems);
        }

        private DataListResponse<MediaViewModel> ToResponse(MediaManagerViewModel request, IQueryable<Media> query)
        {
            var count = query.ToRowCountFutureValue();
            query = AddOrder(query, request).AddPaging(request);

            var items = query.Select(SelectItem).ToList();

            return new DataListResponse<MediaViewModel>(items, count.Value);
        }

        /// <summary>
        /// Adds the order.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="request">The request.</param>
        /// <returns>Ordered query</returns>
        private IQueryable<Media> AddOrder(IQueryable<Media> query, MediaManagerViewModel request)
        {
            IOrderedQueryable<Media> orderedQuery;
            if (request.Direction == SortDirection.Descending)
            {
                orderedQuery = query.OrderBy(m => m.ContentType);
            }
            else
            {
                orderedQuery = query.OrderByDescending(m => m.ContentType);
            }

            if (request.Column == "FileExtension")
            {
                Expression<Func<Media, string>> expression = m => m is MediaFile ? ((MediaFile)m).OriginalFileExtension : m.Title;
                if (request.Direction == SortDirection.Descending)
                {
                    query = orderedQuery.ThenByDescending(expression);
                }
                else
                {
                    query = orderedQuery.ThenBy(expression);
                }
            }
            else
            {
                query = orderedQuery.ThenBy(request.Column, request.Direction);
            }

            return query;
        }

        /// <summary>
        /// Selects all items.
        /// </summary>
        /// <param name="media">The media.</param>
        /// <returns>Entity converted to view model</returns>
        private MediaViewModel SelectItem(Media media)
        {
            if (media is MediaFolder)
            {
                var folder = new MediaFolderViewModel();
                FillMediaViewModel(folder, media);
                return folder;
            }

            return ToViewModel(media);
        }

        /// <summary>
        /// Converts entity to view model.
        /// </summary>
        /// <param name="media">The media.</param>
        /// <returns>Entity converted to view model</returns>
        protected virtual MediaViewModel ToViewModel(Media media)
        {
            var file = media as MediaFile;
            if (file != null)
            {
                var model = new MediaImageViewModel();
                FillMediaFileViewModel(model, file);

                return model;
            }

            throw new InvalidOperationException("Cannot convert media to media view model. Wrong entity passed.");
        }

        /// <summary>
        /// Fills the media view model with entity data.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="media">The media.</param>
        protected void FillMediaViewModel(MediaViewModel model, Media media)
        {
            model.Id = media.Id;
            model.Version = media.Version;
            model.Name = media.Title;
            model.CreatedOn = media.CreatedOn;
            model.Type = media.Type;
            model.IsArchived = media.IsArchived;
            model.ParentFolderId = media.Folder != null ? media.Folder.Id : Guid.Empty;
            model.ParentFolderName = media.Folder != null ? media.Folder.Title : MediaGlobalization.MediaList_RootFolderName;
            model.Tooltip = media.Image != null ? media.Image.Caption : null;
            model.ThumbnailUrl = media.Image != null ? media.Image.PublicThumbnailUrl : null;
        }

        /// <summary>
        /// Fills the media file view model with entity data.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="media">The media.</param>
        protected void FillMediaFileViewModel(MediaFileViewModel model, MediaFile media)
        {
            FillMediaViewModel(model, media);

            model.PublicUrl = media.PublicUrl;
            model.FileExtension = media.OriginalFileExtension;
            model.Size = media.Size;
            model.IsProcessing = media.IsUploaded == null;
            model.IsFailed = media.IsUploaded == false;
        }
    }
}