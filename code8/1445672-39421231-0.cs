        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "DateRoute",
                url: "{controller}/{action}/{date}",
                defaults: new { controller = "YourController", action = "Date", date = UrlParameter.Optional }
            );
            routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
        }
