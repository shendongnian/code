        public static class UnityConfig
        {
            public static void RegisterComponents()
            {
			    var container = new UnityContainer();
                container.RegisterType<<IProductRepo>,<ProductRepo>> (new ContainerControlledLifetimeManager());
                container.Resolve<IProductRepo>();
            
                GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            }
        }
