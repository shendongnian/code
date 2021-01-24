    using System.Web.Routing;
    using EPiServer.Web.Routing;
    public static class PageDataExtensions
    {
    
        public static VirtualPathData FriendlyUrl(this ContentReference contentReference)
        {
            return ServiceLocator.Current.GetInstance<UrlResolver>().GetVirtualPath(contentReference);
        }
    
        public static VirtualPathData FriendlyUrl(this PageData pageData)
        {
            var contentReference = pageData.ContentLink;
            return ServiceLocator.Current.GetInstance<UrlResolver>().GetVirtualPath(contentReference);
        }
    
        public static VirtualPathData FriendlyUrl(this IContent iContent)
        {
            var contentReference = iContent.ContentLink;
            return ServiceLocator.Current.GetInstance<UrlResolver>().GetVirtualPath(contentReference);
        }
    }
