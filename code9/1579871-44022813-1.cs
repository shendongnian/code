    var container = new UnityContainer();
    container.RegisterType<IDependency, Dependency>();   
    
    var b = new Provider(container.Resolve<IDependency>());
    
    container.RegisterType<ITracker, Tracker>
    (
        new ContainerControlledLifetimeManager(),
          new InjectionConstructor(
            new InjectionParameter<IProvider>(b)
    ));
    
    container.RegisterType<IProvider, Tracker>
    (
        new ContainerControlledLifetimeManager(),
          new InjectionConstructor(
            new InjectionParameter<IProvider>(b)
    ));
    
    var p = container.Resolve<IProvider>() as ITracker;
    var t = container.Resolve<ITracker>();
