﻿using System;
using System.Runtime.Serialization;

using BetterCms.Module.Api.Infrastructure;

using ServiceStack.ServiceHost;

namespace BetterCms.Module.Api.Operations.Pages.Sitemaps.Sitemap.Nodes.Node
{
    [Route("/sitemaps/{SitemapId}/nodes/{NodeId}", Verbs = "GET")]
    [Serializable]
    [DataContract]
    public class GetSitemapNodeRequest : RequestBase<GetSitemapNodeModel>, IReturn<SitemapNodeModel>
    {
        [DataMember]
        public Guid SitemapId { get; set; }

        [DataMember]
        public Guid NodeId { get; set; }
    }
}