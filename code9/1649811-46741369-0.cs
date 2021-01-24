    routes.MapRoute(
        "Home", // Route name
        "", // URL with parameters
        new { controller = "Home", action = "Index", portal = String.Empty } // Parameter defaults
    );
    routes.MapRoute(
        "PortalDefault", // Route name
        "Portal/{controller}/{action}/{id}", // URL with parameters
        new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
    );
    routes.MapRoute(
        "Default", // Route name
        "{controller}/{action}/{id}", // URL with parameters
        new { controller = "Home", action = "Index", id = UrlParameter.Optional, portal = String.Empty } // Parameter defaults
    );
