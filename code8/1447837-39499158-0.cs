    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.LowercaseUrls = true;
    
        routes.MapRoute(
            "Admin_default",
            "Admin/{controller}/{action}/{id}",
            new { controller ="LogIn", action = "Index", id = UrlParameter.Optional }
        );
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
    }
