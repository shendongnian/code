    public static void Register(HttpConfiguration config)
    {
        // Web API configuration and services
        // Web API routes
        //config.MapHttpAttributeRoutes();
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{action}/{id}",
            defaults: new { action = "index", id = RouteParameter.Optional }
        );
    }
Now the Action is part of the template, with a default value of index, you will have the following:
