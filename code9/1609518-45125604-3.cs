    public static void RegisterRoutes(RouteCollection routes) 
    { 
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute("history", "{controller}/{action}/{id}",
                         new { controller = "Teum", action = "ClosedEvents", id = UrlParameter.Optional }
                    );
     }
