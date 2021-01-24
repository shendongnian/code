        public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                var settings = config.Formatters.JsonFormatter.SerializerSettings;
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                settings.Formatting = Newtonsoft.Json.Formatting.Indented;
                config.MapHttpAttributeRoutes();
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{action}",
                    defaults: new { id = RouteParameter.Optional }
                );
             }
         }
