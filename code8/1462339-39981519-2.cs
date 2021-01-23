    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
             config.Routes.MapRoute(
               name: "GamesRoute2",
               routeTemplate: "api/games/GameById/{id}",
               defaults: new { controller = "games", action = "GameById" },
               constraints: new { id = @"\d+" }
            );
        
            config.Routes.MapRoute(
                name: "GamesRoute",
                routeTemplate: "api/{controller}/{deviceId}",
                defaults: new { controller = "controller", action = "get", deviceId = UrlParameter.Optional }
        
            );
         }
    }
