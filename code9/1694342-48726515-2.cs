    public static class RouteCollectionExtensions
    {
        public static void MapServiceRoutes(
            this RouteCollection routes,
            Dictionary<string, string> urlToVirtualPathMap,
            object defaults = null,
            object constraints = null)
        {
            foreach (var kvp in urlToVirtualPathMap)
                MapServiceRoute(routes, null, kvp.Key, kvp.Value, defaults, constraints);
        }
        public static Route MapServiceRoute(
            this RouteCollection routes, 
            string url, 
            string virtualPath, 
            object defaults = null, 
            object constraints = null)
        {
            return MapServiceRoute(routes, null, url, virtualPath, defaults, constraints);
        }
        public static Route MapServiceRoute(
            this RouteCollection routes, 
            string routeName, 
            string url, 
            string virtualPath, 
            object defaults = null, 
            object constraints = null)
        {
            if (routes == null)
                throw new ArgumentNullException("routes");
            Route route = new ServiceRoute(
                url: url,
                virtualPath: virtualPath,
                defaults: new RouteValueDictionary(defaults) { { "controller", null }, { "action", null } },
                constraints: new RouteValueDictionary(constraints)
            );
            routes.Add(routeName, route);
            return route;
        }
    }
