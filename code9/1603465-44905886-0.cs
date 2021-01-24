    pubic class ModuleInitializer : IModuleInitializer{
        public void Init(IServiceCollection serviceCollection) {
            serviceCollection.AddTransient<ICollector, CollectorA>();
            serviceCollection.AddTransient<ICollector, CollectorB>();
            serviceCollection.AddTransient<ICollector, CollectorC>();
        }
    }
