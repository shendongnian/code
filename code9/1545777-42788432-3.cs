In order to configure your MVC controller route, ensure to have a class as follow in your App_Start folder:
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
Then, from the Global.asax, in Application_Start method, ensure to have the following call:
    RouteConfig.RegisterRoutes(RouteTable.Routes);
