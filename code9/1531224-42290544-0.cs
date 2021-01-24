    ContainerBuilder builder = new ContainerBuilder();
    builder
        .RegisterType<A>()
        .Named<IA>(nameof(A))
        .SingleInstance();
    builder
        .RegisterType<A_Decorator>()
        .Named<IA>(nameof(A_Decorator))
        .Named<IB>(nameof(A_Decorator))
        .WithParameter(new ResolvedParameter((pi, c) => pi.Name == "decoratedA", 
            (pi, c) => c.ResolveNamed<IA>(nameof(A))))
        .SingleInstance();
    builder
        .RegisterType<AB_Decorator>()
        .As<IA, IB>()
        .WithParameter(new ResolvedParameter((pi, c) => pi.Name == "decoratedA",
            (pi, c) => c.ResolveNamed<IA>(nameof(A_Decorator))))
        .WithParameter(new ResolvedParameter((pi, c) => pi.Name == "decoratedB",
            (pi, c) => c.ResolveNamed<IB>(nameof(A_Decorator))))
        .SingleInstance();
            
    IContainer container = builder.Build();
