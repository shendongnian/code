     public static class UnityConfig
            {
                public static void RegisterComponents()
                {
    // register all your components with the container here
                // it is NOT necessary to register your controllers
    
                // e.g. container.RegisterType<ITestService, TestService>();
                    var container = new UnityContainer();
                    container.RegisterType<IRepository,Repository>();
                    
                    GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
                }
            }
