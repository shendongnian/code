    var container = new UnityContainer();
    
    var b = new Provider();
    
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
