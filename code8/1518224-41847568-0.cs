    Bind<IProcessContext>()
        .To<ProcessContext>()
        .WithConstructorArgument("iamInterface", context => Kernel.Get<Implement1>())
        .Named("Imp1");
        
    Bind<IProcessContext>()
        .To<ProcessContext>()
        .WithConstructorArgument("iamInterface", context => Kernel.Get<Implement2>())
        .Named("Imp2");
    
    kernel.Get<IProcessContext>("Imp1");
