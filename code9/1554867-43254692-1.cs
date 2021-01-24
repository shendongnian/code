         public static void Register(HttpConfiguration config)
        {
            //config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                            name: "Employee",
                            routeTemplate: "api/{controller}/{id}",
                            defaults: new { id = RouteParameter.Optional }
                        );
            //config.EnableQuerySupport();
        }
