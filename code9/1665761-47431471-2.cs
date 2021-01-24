    var container = new WindsorContainer();
    container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
    container.Register(Component.For<Dispatcher>());
    container.Register(
    Classes.FromThisAssembly()
    .BasedOn(typeof(IHandler))
    .WithServiceFromInterface(typeof(IHandler)));
    //dispatch
    var dispatcher = container.Resolve<Dispatcher>();
    dispatcher.Dispatch(new Message());
