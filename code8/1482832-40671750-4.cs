    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
    
            // Convention-based routing.
            //GET api/file
            //POST api/file
            //DELETE api/file/somefilename
            config.Routes.MapHttpRoute(
                name: "FileApi",
                routeTemplate: "api/file/{fileName}",
                defaults: new { controller = "File", fileName = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
