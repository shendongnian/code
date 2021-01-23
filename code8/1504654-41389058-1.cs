    // Magic?
    builder.RegisterType<Portfolio>()
           .As<IPortfolio>()
           .EnableInterfaceInterceptors()
           .InterceptedBy(typeof(CallLogger));;
    builder.Register(c => new CallLogger(Console.Out));
    var container = builder.Build();
    var isResolved = container.Resolve<IPortfolio>();
