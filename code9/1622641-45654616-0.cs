    public static void RegisterRoutes(RouteCollection routes) {
          routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
 
          //Enable attribute routing
          routes.MapMvcAttributeRoutes();
          //convention-based routing
          routes.MapRoute(
              name: "Default",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Welcome", action = "Index", id = UrlParameter.Optional}
          );
    }
