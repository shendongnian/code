    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute(
            "Blog",                                           // Route name
            "Archive/{entryDate}",                            // URL with parameters
            new { controller = "Archive", action = "Entry" }  // Parameter defaults
        );
        routes.MapRoute(
            "Default",                                              // Route name
            "{controller}/{action}/{id}",                           // URL with parameters
            new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
        );
    }
