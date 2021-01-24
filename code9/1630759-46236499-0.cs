		private static IdentityServerServiceFactory Configure(this IdentityServerServiceFactory factory, CormarConfig config)
		{
			var serviceOptions = new EntityFrameworkServiceOptions { ConnectionString = config.SqlConnectionString };
			factory.RegisterOperationalServices(serviceOptions);
			factory.RegisterConfigurationServices(serviceOptions);
			factory.CorsPolicyService = new Registration<ICorsPolicyService>(new DefaultCorsPolicyService { AllowAll = true }); // Allow all domains to access authentication
			factory.Register<DbContext>(new Registration<DbContext>(dr => dr.ResolveFromAutofacOwinLifetimeScope<DbContext>()));
			factory.UserService = new Registration<IUserService>(dr => dr.ResolveFromAutofacOwinLifetimeScope<IUserService>());
			factory.ClientStore = new Registration<IClientStore>(dr => dr.ResolveFromAutofacOwinLifetimeScope<IClientStore>());
			factory.ScopeStore = new Registration<IScopeStore>(dr => dr.ResolveFromAutofacOwinLifetimeScope<IScopeStore>());
			return factory;
		}
