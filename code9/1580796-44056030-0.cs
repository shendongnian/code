    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Web API routes
    
            //Enable Attribute routing is they are being used.
            config.MapHttpAttributeRoutes();
    
            //Convention based routes.
            //Matches GET /api/FavoriteArticles/SetFavorite
            config.Routes.MapHttpRoute(
                name: "DefaultActionApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //Matches GET /api/FavoriteArticles
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
