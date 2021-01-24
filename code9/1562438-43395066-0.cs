    container.RegisterConditional<IService, ServiceWithLogging>(
        c => c.Consumer.ImplementationType == typeof(Consumer1));
    container.RegisterConditional<IService, ServiceWithCaching>(
        c => c.Consumer.ImplementationType != typeof(Consumer1)
            && c.Consumer.ImplementationType != typeof(ServiceWithCaching));
    container.RegisterConditional<IService, Service>(c => !c.Handled);
