    public class ServiceRoute : Route
    {
        public ServiceRoute(string url, string virtualPath, RouteValueDictionary defaults, RouteValueDictionary constraints)
            : base(url, defaults, constraints, new ServiceRouteHandler(virtualPath))
        {
            this.VirtualPath = virtualPath;
        }
        public string VirtualPath { get; private set; }
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            // Run a test to see if the URL and constraints don't match
            // (will be null) and reject the request if they don't.
            if (base.GetRouteData(httpContext) == null)
                return null;
            // Use URL rewriting to fake the query string for the ASMX
            httpContext.RewritePath(this.VirtualPath);
            return base.GetRouteData(httpContext);
        }
    }
