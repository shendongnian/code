    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
            // route default URL to index.aspx
            routes.MapPageRoute(
                routeName: "DefaultToHTML",
                routeUrl: "",
                physicalFile: "~/index.aspx",
                checkPhysicalUrlAccess: false,
                defaults: new RouteValueDictionary(),
                constraints: new RouteValueDictionary { {  "placeholder", ""} }
            );
    
            // other routes go here...
    
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
