     public static void RegisterRoutes(RouteCollection routes)
     {
                routes.MapRoute(
                    "Default", // Route name
                    "{controller}/{action}/{id}", // URL with parameters
                    new { controller = "Controller", action = "Index", id = UrlParameter.Optional });
      }
