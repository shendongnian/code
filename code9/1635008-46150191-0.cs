    public class RouteConfig
    {
     public static void RegisterRoutes(RouteCollection routes)
     {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute(
            name: "customer",
            url: "customer",
            defaults: new { controller = "Customer", action = "Index"}
        );
        routes.MapRoute(
            name: "customerDetail",
            url: "customer/{name}/{id}",
            defaults: new { controller = "Customer", action = "Details", name = UrlParameter.Optional } // Removed idas optional from existing code
        );
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
        );
    }
}
