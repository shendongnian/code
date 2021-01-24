    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            //...other code removed for brevity
    
            //Attribute routes
            routes.MapMvcAttributeRoutes();
            //convention-based routes
            //...other code removed for brevity
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = "" }
            );
        }
    }
