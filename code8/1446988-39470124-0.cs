     public static void RegisterRoutes(RouteCollection routes)
        {                  
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
            "Home",
            **"Edit/{productId}",**
            new { controller = "Home", action = "Edit" },
            new { productId = @"\w+" }
            );
        } 
