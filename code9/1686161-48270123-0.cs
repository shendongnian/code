    var container = new Container();
    container.Options.DefaultLifestyle = new WebRequestLifestyle();
    container.RegisterSingleton<Scheduler>();
    container.Register<ISchedulerFactory>(() => new StdSchedulerFactory(), Lifestyle.Singleton);
    container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
    container.Verify();
    DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
