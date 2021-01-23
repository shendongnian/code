    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute( 
            name: "Default2",
            url: "{controller}/{action}/id/{id}", //Custom url route
            defaults: new { controller = "Product", action = "AddImages", id = UrlParameter.Optional }
        );
    }
