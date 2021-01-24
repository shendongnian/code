    public static void RegisterRoutes(RouteCollection routes)  
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
        // Use specific rout for all other pages:
        routes.MapRoute("WhateverA", "WhateverA/{action}/{id}",
            new { controller = "WhateverA", action = "Index", id = UrlParameter.Optional }
        );
        routes.MapRoute("WhateverB", "WhateverB/{action}/{id}",
            new { controller = "WhateverB", action = "Index", id = UrlParameter.Optional }
        );
    
        // Map to specific pages under Shared controller:
        routes.MapRoute("RootPages", "{action}/{id}",
            new { controller = "Shared", action = "Index", id = UrlParameter.Optional });
    
        // Show the Error page for anything else (404):
        routes.MapRoute("Error", "{*url}",
            new { controller = "Shared", action = "Error" }
        );
    }
