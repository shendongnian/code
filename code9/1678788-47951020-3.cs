    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        AreaRegistration.RegisterAllAreas();
        routes.MapRoute(
            name: "Default",
            url: "{language}/{controller}/{action}/{id}",
            defaults: new { language = "en-US", controller = "Home", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "Testing.Controllers" }
        );
    }
