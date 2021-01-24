     public static void Register(HttpConfiguration config)
     {
         // Web API configuration and services
         EnableCrossSiteRequests(config);
         // Web API routes
         config.MapHttpAttributeRoutes();
         GlobalConfiguration.Configuration.Formatters.JsonFormatter
             .SerializerSettings.ContractResolver =  
                        new CamelCasePropertyNamesContractResolver();
    
         config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
     }
