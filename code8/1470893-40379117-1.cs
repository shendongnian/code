	var container = new WindsorContainer();
	// ...
	container.AddFacility<TypedFactoryFacility>();
	container.AddFacility<WcfFacility>(f => f.CloseTimeout = TimeSpan.Zero);
	container.Register(
		Component.For<Func<IWcfEndpoint, IService>>().AsFactory(),
		Component.For<ServiceFactory>().ImplementedBy<ServiceFactory>());	
