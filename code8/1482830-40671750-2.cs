    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
    
            // Convention-based routing.
            config.Routes.MapHttpRoute(
                name: "PhotoApi",
                routeTemplate: "api/photo/{action}/{fileName}",
                defaults: new { controller = "File", action = "Get", fileName = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "FileApi",
                routeTemplate: "api/file/{action}/{fileName}",
                defaults: new { controller = "File", action = "Get", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
