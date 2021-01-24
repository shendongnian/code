    public static void RegisterRoutes(RouteCollection routes) {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.IgnoreRoute("{resource}.ashx/{*pathInfo}");
        ...
    }
