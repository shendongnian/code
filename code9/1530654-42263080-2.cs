    public static void RegisterRoutes(RouteCollection routes)  
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        //Attribute routing
        routes.MapMvcAttributeRoutes();
    
        // Map to specific pages under Shared controller:
        routes.MapRoute("RootPages", "{action}/{id}",
            new { controller = "Shared", action = "Index", id = UrlParameter.Optional });
    
        // Show the Error page for anything else (404):
        routes.MapRoute("Error", "{*url}",
            new { controller = "Shared", action = "Error" }
        );
    }
