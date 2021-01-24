    void RegisterConfiguration(ContainerBuilder builder)
    {
        builder.RegisterType<Configuration>()
               .As<IConfiguration>()
               .SingleInstance();
        builder.Register(c => c.Resolve<Iconfiguration>()
                               .Service1Configuration)
               .As<IService1Configuration>();
        builder.Register(c => c.Resolve<IConfiguration>()
                               .Service2Configuration)
               .As<IService2Configuration>();
    }
