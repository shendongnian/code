    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
    
            // Convention-based routing.
            config.Routes.MapHttpRoute(
                name: "PhotoApi",
                routeTemplate: "api/photo/{id}",
                defaults: new { controller = "Photo", id = RouteParameter.Optional }
            );
            //even without the one above this one should still work for `api/photo`
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
