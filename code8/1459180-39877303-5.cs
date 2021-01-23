    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
           
            routes.MapRoute(
               name: "postOnlyParam",
               url: "post/{postName}",
               defaults: new { controller = "Post", action = "ReadPost", postName = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "post",
              url: "post/{action}/{postName}",
              defaults: new { controller = "Post", action = "ReadPost", postName = UrlParameter.Optional }
          );
        }
    }
