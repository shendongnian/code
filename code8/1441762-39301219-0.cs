    // ...
    // Web API configuration and services
    var container = new UnityContainer();
    UnityConfig.RegisterComponents();
    config.DependencyResolver = new UnityResolver(container);
