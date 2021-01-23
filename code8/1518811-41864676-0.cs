    public class RouteConfig 
    {
        public static void RegisterRoutes(RouteCollection routes) 
        {
            routes.MapRoute(
                    name: "Default", // Route name
                    url: "{controller}/{action}/{id}", // URL with parameters
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }
    }
