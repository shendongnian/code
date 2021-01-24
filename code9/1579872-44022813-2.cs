    var container = new UnityContainer();
    container.RegisterType<IDependency, Dependency>();   
    container.RegisterType<IProvider, Provider>("Provider");
    
    
    container.RegisterType<ITracker, Tracker>
    (
        new ContainerControlledLifetimeManager(),
          new InjectionConstructor(
            new ResolvedParameter<IProvider>("Provider")
    ));
    
    container.RegisterType<IProvider, Tracker>
    (
        new ContainerControlledLifetimeManager(),
          new InjectionConstructor(
            new ResolvedParameter<IProvider>("Provider")
    ));
    
    var p = container.Resolve<IProvider>() as ITracker;
    var t = container.Resolve<ITracker>();
