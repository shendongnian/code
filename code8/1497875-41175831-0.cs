    public static void Register(HttpConfiguration config) {
        // Web API configuration and services
        // Web API routes
        config.MapHttpAttributeRoutes();
        config.Routes.MapHttpRoute(
            name: "ControllerAndAction",
            routeTemplate: "api/{controller}/{action}/{id}"
            defaults: new { id = RouteParameter.Optional }
        );
        config.Routes.MapHttpRoute(
            name: "ControllerandId",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
    }
