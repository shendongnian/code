    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "dashboard", action = "index", id = UrlParameter.Optional },
                namespaces: new[] { "Company.Project.Web.UI.Controllers" }
            );
        }
    }
