    public static void RegisterRoutes(RouteCollection routes) {
        routes.IgnoreRoute(“{resource}.axd/{*pathInfo}”);
        //enable attribute routing     
        routes.MapMvcAttributeRoutes();
        //covention-based routes
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
    }
