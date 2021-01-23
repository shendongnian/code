     public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // Controllers with Actions
            // To handle routes like `/api/VTRouting/route`
            config.Routes.MapHttpRoute(
                name: "DefaultApiwithActionID",
                routeTemplate: "api/{controller}/{action}/{id}",
                 defaults: new { id = RouteParameter.Optional } 
            );
        }
