    public static void RegisterRoutes(RouteCollection routes)  
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
        // Use the default rout for all other pages:
        routes.MapRoute("Default", "{controller}/{action}/{id}",
            new { controller = "Shared", action = "Index", id = UrlParameter.Optional }
        );
    
        // Map to specific pages under Shared controller:
        routes.MapRoute("SharedPages", "{action}/{id}",
            new { controller = "Shared", action = @"Overview|Recordings", id = UrlParameter.Optional });
    
        // Show the Error page for anything else (404):
        routes.MapRoute("Error", "{*url}",
            new { controller = "Shared", action = "Error" }
        );
    }
