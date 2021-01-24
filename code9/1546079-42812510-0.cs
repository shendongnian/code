    var container = UnityConfig.GetConfiguredContainer();
    FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
    FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));
    //MVC
    DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
    //Web API
    GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
