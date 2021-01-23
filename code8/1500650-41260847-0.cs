    container.RegisterType<IInterface1, Implementation1>();
    container.RegisterType<IInterface2, Implementation2>();
    
    container.RegisterType<MyController>(new InjectionConstructor(
        container.Resolve<IInterface1>(), 
        container.Resolve<IInterface2>()));
