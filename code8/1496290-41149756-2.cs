            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DataApiRoute",
                routeTemplate: "api/{model}/{action}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    controller = "DataApi"
                }
            );
            // IOC
            var container = new UnityContainer();
            container.RegisterInstance(IocConfig.RegisterTheseInstances());
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
