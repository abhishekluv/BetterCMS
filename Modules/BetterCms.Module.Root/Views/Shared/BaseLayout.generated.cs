﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 1 "..\..\Views\Shared\BaseLayout.cshtml"
    using BetterCms.Module.Root.Mvc;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\Shared\BaseLayout.cshtml"
    using BetterCms.Module.Root.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Shared\BaseLayout.cshtml"
    using BetterCms.Module.Root.ViewModels.Cms;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/BaseLayout.cshtml")]
    public partial class _Views_Shared_BaseLayout_cshtml : System.Web.Mvc.WebViewPage<RenderPageViewModel>
    {
        public _Views_Shared_BaseLayout_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 6 "..\..\Views\Shared\BaseLayout.cshtml"
  
    Layout = "RootLayout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 10 "..\..\Views\Shared\BaseLayout.cshtml"
 if (Model.CanManageContent)
{
    
            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\Shared\BaseLayout.cshtml"
Write(Html.Partial("~/Areas/bcms-root/Views/Shared/Partial/SupportBrowser.cshtml"));

            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\Shared\BaseLayout.cshtml"
                                                                                 
    
            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Shared\BaseLayout.cshtml"
Write(Html.Partial("~/Areas/bcms-root/Views/Shared/Partial/SupportJavascript.cshtml"));

            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Shared\BaseLayout.cshtml"
                                                                                    
    
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Shared\BaseLayout.cshtml"
Write(Html.Partial("~/Areas/bcms-root/Views/Shared/Partial/MasterPagesPath.cshtml"));

            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Shared\BaseLayout.cshtml"
                                                                                  
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 17 "..\..\Views\Shared\BaseLayout.cshtml"
Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

DefineSection("CmsMetaTitle", () => {

WriteLiteral("\r\n    <title>");

            
            #line 20 "..\..\Views\Shared\BaseLayout.cshtml"
      Write(Model.MetaTitle);

            
            #line default
            #line hidden
WriteLiteral("</title>\r\n");

});

WriteLiteral("\r\n");

DefineSection("CmsMeta", () => {

WriteLiteral("    \r\n");

            
            #line 24 "..\..\Views\Shared\BaseLayout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\Shared\BaseLayout.cshtml"
     if (Model.Metadata != null)
    {
        foreach (var metaData in Model.Metadata)
        {
            metaData.Render(Model, (ViewContext.Controller as CmsControllerBase).SecurityService, Html);
        }
    }

            
            #line default
            #line hidden
});

DefineSection("CmsHeadStyles", () => {

WriteLiteral("   \r\n    <style");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(">\r\n        .bcms-clearfix:after {\r\n            content: \"\";\r\n            visibili" +
"ty: hidden;\r\n            display: block;\r\n            height: 0;\r\n            cl" +
"ear: both;\r\n        }\r\n    </style>\r\n");

            
            #line 42 "..\..\Views\Shared\BaseLayout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 42 "..\..\Views\Shared\BaseLayout.cshtml"
     if (Model.CanManageContent)
    {
        
            
            #line default
            #line hidden
            
            #line 44 "..\..\Views\Shared\BaseLayout.cshtml"
   Write(Html.Action("RenderStyleSheetIncludes", "Rendering"));

            
            #line default
            #line hidden
            
            #line 44 "..\..\Views\Shared\BaseLayout.cshtml"
                                                             
    }

            
            #line default
            #line hidden
});

WriteLiteral("\r\n");

DefineSection("CmsHeadScripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 49 "..\..\Views\Shared\BaseLayout.cshtml"
Write(RenderSection("CmsHeadScripts", false));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 51 "..\..\Views\Shared\BaseLayout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 51 "..\..\Views\Shared\BaseLayout.cshtml"
     if (Model.CanManageContent)
    {

            
            #line default
            #line hidden
WriteLiteral("        <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
            function loadBetterCmsScriptAsync(url, callback) {
                var head = document.getElementsByTagName(""head"")[0];
                var scriptTag = document.createElement(""script"");
                scriptTag.type = 'text/javascript';
                scriptTag.src = url;
                scriptTag.async = true;

                // Attach handlers for all browsers
                var done = false;
                scriptTag.onload = scriptTag.onreadystatechange = function() {
                    if (!done && (!this.readyState || this.readyState == ""loaded"" || this.readyState == ""complete"")) {
                        done = true;
                        try {
                            if (callback) {
                                callback();
                            }
                        } finally {
                            scriptTag.onload = scriptTag.onreadystatechange = null;
                            head.removeChild(scriptTag);
                        }
                    }
                };

                head.appendChild(scriptTag);
            }

            (function() {
                loadBetterCmsScriptAsync('");

            
            #line 81 "..\..\Views\Shared\BaseLayout.cshtml"
                                     Write(Model.RequireJsPath);

            
            #line default
            #line hidden
WriteLiteral("\', function() {\r\n                    loadBetterCmsScriptAsync(\'");

            
            #line 82 "..\..\Views\Shared\BaseLayout.cshtml"
                                         Write(Model.MainJsPath);

            
            #line default
            #line hidden
WriteLiteral("\');\r\n                });\r\n            })();\r\n        </script>\r\n");

WriteLiteral("        <!--[if lt IE 9]>\r\n            <script src=\"");

            
            #line 87 "..\..\Views\Shared\BaseLayout.cshtml"
                    Write(Model.Html5ShivJsPath);

            
            #line default
            #line hidden
WriteLiteral("\"></script>\r\n        <![endif]-->\r\n");

            
            #line 89 "..\..\Views\Shared\BaseLayout.cshtml"
    }

            
            #line default
            #line hidden
});

WriteLiteral("\r\n");

DefineSection("CmsScripts", () => {

WriteLiteral("\r\n");

            
            #line 93 "..\..\Views\Shared\BaseLayout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 93 "..\..\Views\Shared\BaseLayout.cshtml"
     if (Model.CanManageContent)
    {
        
            
            #line default
            #line hidden
            
            #line 95 "..\..\Views\Shared\BaseLayout.cshtml"
   Write(Html.Partial("Partial/Region"));

            
            #line default
            #line hidden
            
            #line 95 "..\..\Views\Shared\BaseLayout.cshtml"
                                       
        
            
            #line default
            #line hidden
            
            #line 96 "..\..\Views\Shared\BaseLayout.cshtml"
   Write(Html.Partial("Partial/ContentOverlay"));

            
            #line default
            #line hidden
            
            #line 96 "..\..\Views\Shared\BaseLayout.cshtml"
                                               
        
            
            #line default
            #line hidden
            
            #line 97 "..\..\Views\Shared\BaseLayout.cshtml"
   Write(Html.Action("Container", "Sidebar", Model));

            
            #line default
            #line hidden
            
            #line 97 "..\..\Views\Shared\BaseLayout.cshtml"
                                                   
        
            
            #line default
            #line hidden
            
            #line 98 "..\..\Views\Shared\BaseLayout.cshtml"
   Write(Html.Partial("Partial/Modal"));

            
            #line default
            #line hidden
            
            #line 98 "..\..\Views\Shared\BaseLayout.cshtml"
                                      
        
            
            #line default
            #line hidden
            
            #line 99 "..\..\Views\Shared\BaseLayout.cshtml"
   Write(Html.Partial("Partial/Alert"));

            
            #line default
            #line hidden
            
            #line 99 "..\..\Views\Shared\BaseLayout.cshtml"
                                      
        
            
            #line default
            #line hidden
            
            #line 100 "..\..\Views\Shared\BaseLayout.cshtml"
   Write(Html.Partial("Partial/Confirm"));

            
            #line default
            #line hidden
            
            #line 100 "..\..\Views\Shared\BaseLayout.cshtml"
                                        
        
            
            #line default
            #line hidden
            
            #line 101 "..\..\Views\Shared\BaseLayout.cshtml"
   Write(Html.Partial("Partial/Delete"));

            
            #line default
            #line hidden
            
            #line 101 "..\..\Views\Shared\BaseLayout.cshtml"
                                       
        
            
            #line default
            #line hidden
            
            #line 102 "..\..\Views\Shared\BaseLayout.cshtml"
   Write(Html.Partial("Partial/Info"));

            
            #line default
            #line hidden
            
            #line 102 "..\..\Views\Shared\BaseLayout.cshtml"
                                     
        
            
            #line default
            #line hidden
            
            #line 103 "..\..\Views\Shared\BaseLayout.cshtml"
   Write(Html.Partial("Partial/Tooltip"));

            
            #line default
            #line hidden
            
            #line 103 "..\..\Views\Shared\BaseLayout.cshtml"
                                        
        
            
            #line default
            #line hidden
            
            #line 104 "..\..\Views\Shared\BaseLayout.cshtml"
   Write(Html.Partial("Partial/ImagePreview"));

            
            #line default
            #line hidden
            
            #line 104 "..\..\Views\Shared\BaseLayout.cshtml"
                                             
        
            
            #line default
            #line hidden
            
            #line 105 "..\..\Views\Shared\BaseLayout.cshtml"
   Write(Html.Partial("Partial/SiteSettingTab"));

            
            #line default
            #line hidden
            
            #line 105 "..\..\Views\Shared\BaseLayout.cshtml"
                                               
        
            
            #line default
            #line hidden
            
            #line 106 "..\..\Views\Shared\BaseLayout.cshtml"
   Write(Html.Partial("Partial/ContentsTree"));

            
            #line default
            #line hidden
            
            #line 106 "..\..\Views\Shared\BaseLayout.cshtml"
                                             
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 109 "..\..\Views\Shared\BaseLayout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 109 "..\..\Views\Shared\BaseLayout.cshtml"
     if (Model.JavaScripts != null)
    {
        
            
            #line default
            #line hidden
            
            #line 111 "..\..\Views\Shared\BaseLayout.cshtml"
   Write(Html.RenderPageCustomJavaScript(Model.JavaScripts, Model));

            
            #line default
            #line hidden
            
            #line 111 "..\..\Views\Shared\BaseLayout.cshtml"
                                                                  
    }

            
            #line default
            #line hidden
});

WriteLiteral("\r\n");

DefineSection("Styles", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 116 "..\..\Views\Shared\BaseLayout.cshtml"
Write(RenderSection("Styles", false));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 118 "..\..\Views\Shared\BaseLayout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 118 "..\..\Views\Shared\BaseLayout.cshtml"
     if (Model.Stylesheets != null)
    {
        
            
            #line default
            #line hidden
            
            #line 120 "..\..\Views\Shared\BaseLayout.cshtml"
   Write(Html.RenderPageCustomCss(Model.Stylesheets, Model));

            
            #line default
            #line hidden
            
            #line 120 "..\..\Views\Shared\BaseLayout.cshtml"
                                                           
    }

            
            #line default
            #line hidden
});

DefineSection("HeadScripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 124 "..\..\Views\Shared\BaseLayout.cshtml"
Write(RenderSection("HeadScripts", false));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

DefineSection("Scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 127 "..\..\Views\Shared\BaseLayout.cshtml"
Write(RenderSection("Scripts", false));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

DefineSection("DoctypeTag", () => {

WriteLiteral(" \r\n");

            
            #line 130 "..\..\Views\Shared\BaseLayout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 130 "..\..\Views\Shared\BaseLayout.cshtml"
     if (IsSectionDefined("DoctypeTag"))
    {
        
            
            #line default
            #line hidden
            
            #line 132 "..\..\Views\Shared\BaseLayout.cshtml"
   Write(RenderSection("DoctypeTag", false));

            
            #line default
            #line hidden
            
            #line 132 "..\..\Views\Shared\BaseLayout.cshtml"
                                           
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral("        ");

WriteLiteral("<!DOCTYPE html>\r\n");

            
            #line 137 "..\..\Views\Shared\BaseLayout.cshtml"
    }

            
            #line default
            #line hidden
});

DefineSection("HtmlTag", () => {

WriteLiteral(" \r\n");

            
            #line 140 "..\..\Views\Shared\BaseLayout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 140 "..\..\Views\Shared\BaseLayout.cshtml"
     if (IsSectionDefined("HtmlTag"))
    {
        
            
            #line default
            #line hidden
            
            #line 142 "..\..\Views\Shared\BaseLayout.cshtml"
   Write(RenderSection("HtmlTag", false));

            
            #line default
            #line hidden
            
            #line 142 "..\..\Views\Shared\BaseLayout.cshtml"
                                        
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral("        ");

WriteLiteral("<html>\r\n");

            
            #line 147 "..\..\Views\Shared\BaseLayout.cshtml"
    }

            
            #line default
            #line hidden
});

DefineSection("BodyTag", () => {

WriteLiteral(" \r\n");

            
            #line 150 "..\..\Views\Shared\BaseLayout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 150 "..\..\Views\Shared\BaseLayout.cshtml"
     if (IsSectionDefined("BodyTag"))
    {
        
            
            #line default
            #line hidden
            
            #line 152 "..\..\Views\Shared\BaseLayout.cshtml"
   Write(RenderSection("BodyTag", false));

            
            #line default
            #line hidden
            
            #line 152 "..\..\Views\Shared\BaseLayout.cshtml"
                                        
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral("        ");

WriteLiteral("<body ");

            
            #line 156 "..\..\Views\Shared\BaseLayout.cshtml"
           Write(Html.RenderBodyAttributes());

            
            #line default
            #line hidden
            
            #line 156 "..\..\Views\Shared\BaseLayout.cshtml"
                                       Write(RenderSection("BodyAttributes", false));

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

            
            #line 157 "..\..\Views\Shared\BaseLayout.cshtml"
    }

            
            #line default
            #line hidden
});

        }
    }
}
#pragma warning restore 1591
