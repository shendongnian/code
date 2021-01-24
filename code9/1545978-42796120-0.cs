       public class RouteConfig
        {
            public static void RegisterRoutes(RouteCollection routes)
            {
                    routes.MapRoute(
                    name: "YOUR NAME",
                    url: "{YOUR CONTROLLER NAME}/{GetJsonTest}",
                    defaults: new { controller = "YOUR CONTROLLER NAME", action = "GetJsonTest" }
                );
        }
        }
