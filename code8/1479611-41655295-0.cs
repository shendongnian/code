     public static class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public static void ConfigureApp(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host.
            HttpConfiguration config = new HttpConfiguration();
            // Allow custom routes in controller attributes.
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { controller = "API", action = "HealthCheck", id = RouteParameter.Optional }
            );
            //inject controllers here
            config.DependencyResolver.GetService(typeof({{YourWebAPIRootNamespace}}.Controllers.APIController));
                        
            appBuilder.UseWebApi(config);
        }
    }
