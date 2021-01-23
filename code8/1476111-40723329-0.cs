    using System;
    using System.Text;
    using Microsoft.SharePoint.Client;
    
    namespace SharePoint2010.CSOM.Extensions
    {
        public static class PublishingPage
        {
            public static void Create(List pagesList,ListItem pageLayout, string pageName, string pageContent)
            {
                var ctx = (ClientContext) pagesList.Context;
                const string publishingPageTemplate =
                    "<%@ Page Inherits=\"Microsoft.SharePoint.Publishing.TemplateRedirectionPage,Microsoft.SharePoint.Publishing,Version=14.0.0.0,Culture=neutral,PublicKeyToken=71e9bce111e9429c\" %> <%@ Reference VirtualPath=\"~TemplatePageUrl\" %> <%@ Reference VirtualPath=\"~masterurl/custom.master\" %>";
                var fileInfo = new FileCreationInformation
                {
                    Url = pageName,
                    Content = Encoding.UTF8.GetBytes(publishingPageTemplate),
                    Overwrite = true
                };
                var pageFile = pagesList.RootFolder.Files.Add(fileInfo);
                var pageItem = pageFile.ListItemAllFields;
    
                if (!ctx.Site.IsPropertyAvailable("ServerRelativeUrl"))
                {
                    ctx.Load(ctx.Site);
                    ctx.ExecuteQuery();
                }
               
                pageItem["PublishingPageLayout"] = string.Format("{0}, {1}", pageLayout["FileRef"], pageLayout["Title"]);
                pageItem["PublishingPageContent"] = pageContent;
                pageItem.Update();
                ctx.ExecuteQuery();
            }
    
    
            public static ListItem GetPageLayout(ClientContext ctx, string name)
            {
                var masterPagesList = ctx.Site.GetCatalog((int) ListTemplateType.MasterPageCatalog);
                var items = masterPagesList.GetItems(CreatePageLayoutByNameQuery(name));
                ctx.Load(items);
                ctx.ExecuteQuery();
                return items.Count == 1 ? items[0] : null;
            }
    
            private static CamlQuery CreatePageLayoutByNameQuery(string name)
            {
                var qry = new CamlQuery();
                qry.ViewXml = "<View>" +
                                  "<Query>" +
                                       "<Where>" +
                                          "<Eq><FieldRef Name='FileLeafRef'/><Value Type='File'>{0}</Value></Eq>" +
                                        "</Where>" +
                                  "</Query>" +
                              "</View>";
                qry.ViewXml = String.Format(qry.ViewXml,name);
                return qry;
            }
        }
    }
 
