    public class RouteConfig {
    
        public static void RegisterRoutes(RouteCollection routes) {
    
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
            routes.MapRoute(
                    name: "DefaultMVC",
                    url: "control/{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
            //..other routes.
        }
    }
