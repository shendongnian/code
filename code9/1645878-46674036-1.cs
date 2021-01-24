     public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IGenericRepository<Cat>, GenericRepository<Cat, AnimalEntities>>(new HierarchicalLifetimeManager(), new InjectionConstructor());
            container.RegisterType<IGenericRepository<Dog>, GenericRepository<Dog, AnimalEntities>>(new HierarchicalLifetimeManager(), new InjectionConstructor());                                  
            config.DependencyResolver = new UnityResolver(container);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
