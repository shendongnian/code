    var builder = new ContainerBuilder();
    builder.RegisterControllers(typeof(MvcApplication).Assembly);
    builder
        .RegisterType<CacheResultInterceptor>()
        .SingleInstance();
    builder
        .RegisterAssemblyTypes(typeof(MvcApplication).Assembly)
        .Where(x => x.Name.EndsWith("Query"))
        .AsImplementedInterfaces()
        .EnableInterfaceInterceptors()
        .InterceptedBy(typeof(CacheResultInterceptor));
    DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
