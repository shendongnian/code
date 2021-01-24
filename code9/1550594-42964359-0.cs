    public class RouteConfig {
    
        public static void RegisterRoutes(RouteCollection routes) {
    
           routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
           routes.MapMvcAttributeRoutes(); //<--IMPORTANT for attribute routing in MVC
    
            // Convention-based routing.
    
            //...other code removed for brevity
        }
    }
