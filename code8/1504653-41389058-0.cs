    // Magic?
    builder.RegisterType<Portfolio>()
           .As<IXInterface>()
           .EnableInterfaceInterceptors();
    builder.Register(c => new CallLogger(Console.Out));
    var container = builder.Build();
    var isResolved = container.Resolve<IXInterface>();
