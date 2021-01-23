     public class RouteConfig
        {
            public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        
                routes.MapRoute(
                    name: "Default",
                    url: "{code}/{culture}/{controller}/{action}/{id}",
                             defaults: new {code ="efs",culture="fr-ca", controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
        
        
                routes.MapRoute("Error", "{*url}", new { controller = "Error", action = "Error" });
            }
        }
