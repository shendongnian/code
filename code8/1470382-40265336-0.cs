            HttpConfiguration = new HttpConfiguration();
            LoggingConfig.RegisterLogger();
            ConfigureOAuth(app);
            var unityContainer = UnityConfig.GetConfiguredContainer();
            HttpConfiguration.DependencyResolver = new UnityDependencyResolver(unityContainer);
            
            //for DI in the filters
            UnityConfig.RegisterFilterProviders(unityContainer, HttpConfiguration);
