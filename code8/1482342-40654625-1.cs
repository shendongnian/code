	var factory = new BasicFactory(container);
	factory.Register<A>("A", Lifestyle.Scoped);
	factory.Register<B>("B", Lifestyle.Scoped);
	
	container.RegisterSingleton<IBasicFactory>(factory)
