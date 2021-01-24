	container.RegisterType<IFirstService, FirstService>(new HierarchicalLifetimeManager());
    container.RegisterType<ISecondService, SecondService>(new HierarchicalLifetimeManager());
    container.RegisterType<IThirdService, ThirdService>(new HierarchicalLifetimeManager());
    container.RegisterType<IFacadeOne, FacadeOne>(new HierarchicalLifetimeManager(),
        new InjectionConstructor(
            new ResolvedParameter<IFirstService>(),
            new ResolvedParameter<ISecondService>()));
    container.RegisterType<IFacadeTwo, FacadeTwo>(new HierarchicalLifetimeManager(),
        new InjectionConstructor(
            new ResolvedParameter<IFirstService>(),
            new ResolvedParameter<IThirdService>()));
    IUnityContainer childContainer = container.CreateChildContainer();
    childContainer.RegisterType<ITaskScheduler, TaskScheduler>(new HierarchicalLifetimeManager(),
        new InjectionConstructor(
            new ResolvedParameter<IFacadeOne>(),
            new ResolvedParameter<IFacadeTwo>()));
    // Resolve at registration time == Bad.
    // You could do a work around too, but that's another lesson!
    ITaskScheduler taskScheduler = childContainer.Resolve<ITaskScheduler>();
    container.RegisterInstance<ITaskScheduler>(taskScheduler);
    container.RegisterType<MainController>(new HierarchicalLifetimeManager(),
        new InjectionConstructor(
            new ResolvedParameter<IFacadeOne>(),
            new ResolvedParameter<IFacadeTwo>(),
            new ResolvedParameter<ITaskScheduler>()));
    MainController imWhatYouShouldntWant = container.Resolve<MainController>();
