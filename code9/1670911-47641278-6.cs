    container.AddFacility<TypedFactoryFacility>();
    container.AddFacility<WcfFacility>();
    container.Register(Component.For<IMyService>()
        .AsWcfClient(WcfEndpoint.FromConfiguration("MyServiceEndpointName")));
    container.Register(Component.For<IMyServiceFactory>().AsFactory());
