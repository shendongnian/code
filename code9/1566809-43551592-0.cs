    using System.Web.Mvc;
    using System.Web.Routing;
    
    namespace WebApplication6
    {
        public class RouteConfig
        {
            public static void RegisterRoutes(RouteCollection routes)
            {
                routes.MapRoute(
                    name: "Default",
                    url: "{controller}/records/{action}/{recordid}",
                    defaults: new { controller = "patient", recordid = UrlParameter.Optional }
                );
            }
        }
    }
