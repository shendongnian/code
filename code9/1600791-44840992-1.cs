     public class RouteConfig
     {
         public static void RegisterRoutes(RouteCollection routes)
         {
             routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
              routes.MapRoute(
                   name: "WebPage",
                   url: "{id}",
                   defaults: new { controller = "Home", action = "WebPage" }
                );
    
                routes.MapRoute(
                        name: "Default",
                        url: "{action}/{id}",
                        defaults: new { controller = "Home", action = "Index",id = UrlParameter.Optional }
                );
            }
    }
