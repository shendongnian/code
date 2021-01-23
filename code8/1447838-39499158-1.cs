    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.LowercaseUrls = true;
    
        routes.MapRoute(
            "Admin_default",
            "Admin/{action}/{id}",
            new { controller ="Admin", action = "Login", id = UrlParameter.Optional }
        );
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
    }
