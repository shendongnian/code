    public static void Register(HttpConfiguration config)
    {
        config.MapHttpAttributeRoutes();
    
        config.Routes.MapHttpRoute(
            name: "BedfordBrownstoneApi",
            routeTemplate: "api/{controller}/{action}",
            defaults: new { action = "GetAgentId" }
        );
    }
