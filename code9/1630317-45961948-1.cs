    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "LogOutRoute",
                url: "Index/LogOut",
                defaults: new { controller = "Index", action = "LogOut" }
            );
            routes.MapRoute(
                name: "Tutorials",
                url: "Index/Tutorials",
                defaults: new { controller = "Index", action = "Tutorials" }
            );
            routes.MapRoute(
                name: "Index",
                url: "Index/{id}",
                defaults: new { controller = "Index", action = "Index" }
            );
            routes.MapRoute(
              name: "ResetPwdRoute",
              url: "User/ResetPwd/{id}",
              defaults: new { controller = "User", action = "ResetPwd", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
