	// In BusinessProcessor
	container.RegisterType<IBusinessProcessorA, MyBusinessProcessorA1>();
	container.RegisterType<IBusinessProcessorA, MyBusinessProcessorA2>();
	container.RegisterType<IBusinessProcessorB, MyBusinessProcessorB1>();
	// In DataAccessLayer
	container.RegisterType<IRepository, Repository<A>>("A", new HierarchicalLifetimeManager());
	container.RegisterType<IRepository, Repository<B>>("B", new HierarchicalLifetimeManager());
	container.RegisterType<IRepository, Repository<C>>("C", new HierarchicalLifetimeManager());
	// In WindowsService
	Register(BusinessProcessor);	// Call to have the BusinessProcessor register it's own things.
	Register(DataAccessLayer);		// Call to have the DataAccessLayer register it's own things.
	container.RegisterType<IService, MyService>();
	// In WebApplication
	Register(BusinessProcessor);	// Call to have the BusinessProcessor register it's own things.
	Register(DataAccessLayer);		// Call to have the DataAccessLayer register it's own things.
	container.RegisterType<IController, MyController>();
	container.RegisterType<IRepository, Repository<A>>("A", new PerRequestLifetimeManager());
