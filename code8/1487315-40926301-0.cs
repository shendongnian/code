	Bind<IUnitOfWork>()
		.To<UnitOfWork>()
		.WhenInjectedInto<IIPOPService>()
		.InRequestScope()
		.WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["IPOP_BE_TESTEntities"].ConnectionString);
	Bind<IUnitOfWork>()
		.To<UnitOfWork>()
		.WhenInjectedInto<IQuoteService>()
		.InRequestScope()
		.WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["IPOP_BAPSEntities"].ConnectionString);
	
	Bind<IRepository<tOrder>>().To<Repository<tOrder>>().InRequestScope();
