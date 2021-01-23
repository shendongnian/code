    public class UrlHelperAdapter : UrlHelper, IUrlHelper
    {
        private UrlHelperAdapter(RequestContext requestContext)
            : base(requestContext)
        {
        }
        public UrlHelperAdapter(RequestContext requestContext, RouteCollection routeCollection)
            : base(requestContext, routeCollection)
        {
        }
    }
