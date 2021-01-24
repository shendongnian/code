    var builder = new ContainerBuilder();
    builder.Register(c => HttpContext.Current.Request).As<HttpRequest>().InstancePerRequest();
    builder.RegisterType<SystemKeyProvider>().AsImplementedInterfaces();
    // service registration
    builder.RegisterType<ExternalSystem>().Keyed<ISystem>(SystemKey.External);
    builder.RegisterType<InternalSystem>().Keyed<ISystem>(SystemKey.Internal);
    builder.Register(c => 
        c.ResolveKeyed<ISystem>(c.Resolve<ISystemKeyProvider>().GetSystemKey()))
        .As<ISystem>();
    builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
    GlobalConfiguration.Configuration.DependencyResolver = 
        new AutofacWebApiDependencyResolver(builder.Build());
