    container.RegisterType<ServiceA>().AsSelf();
    container.RegisterType<ServiceB>().AsSelf();
    container.Register<ISubFactory>(c =>
        new DispatchingSubFactoryProxy(
            aFactory: new SubFactory(c.Resolve<ServiceA>())
            bFactory: new SubFactory(c.Resolve<ServiceB>())));
