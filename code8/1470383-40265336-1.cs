        public static void RegisterFilterProviders(IUnityContainer UnityDependencyResolver, HttpConfiguration configuration)
        {
            var providers = configuration.Services.GetFilterProviders().ToList();
            
            configuration.Services.Add(
                typeof(IFilterProvider),
                new UnityActionFilterProvider(UnityDependencyResolver));
            var defaultprovider = providers.First(p => p is ActionDescriptorFilterProvider);
            configuration.Services.Remove(typeof(IFilterProvider), defaultprovider);
        }
