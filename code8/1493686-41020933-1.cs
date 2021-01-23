    public static void Register(HttpConfiguration config)
    {
        // Web API routes
        config.MapHttpAttributeRoutes();
    
        config.Routes.MapHttpRoute(
                        name: "defaultApiRoutes",
                        routeTemplate: "api/{controller}/{action}/{id}",
                        defaults: new { id = RouteParameter.Optional }
                    );
    
    }
