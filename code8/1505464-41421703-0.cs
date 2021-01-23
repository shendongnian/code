    public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
           routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Read", action = "Index" }
            );
    
            routes.MapRoute(
                name: "View",
                url: "{controller}/{action}/{id}/{cid}/{pid}",
                defaults: new { controller = "Read", action = "R", id = UrlParameter.Optional, cid = UrlParameter.Optional, pid = UrlParameter.Optional }
            );
    
            routes.MapRoute(
                name: "JsonResult",
                url: "{controller}/{id}/{cid}/{pid}", /*Changed to Controller here*/
                defaults: new { controller = "Find", action = "Readable", id = UrlParameter.Optional, cid = UrlParameter.Optional, pid = UrlParameter.Optional}
            );
    
        }
