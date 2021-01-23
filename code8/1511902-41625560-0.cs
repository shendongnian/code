    container = new Container();
    container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();
    
    container.RegisterSingleton(() => new SimpleInjectorSignalRDependencyResolver(_container));
    container.RegisterSingleton(() =>
    	new HubConfiguration()
    	{
    		EnableDetailedErrors = true,
    		Resolver = _container.GetInstance<SimpleInjectorSignalRDependencyResolver>()
    	});
    
    container.RegisterSingleton<IHubActivator, SimpleInjectorHubActivator>();
    container.RegisterSingleton<IStockTicker,StockTicker>();
    container.RegisterSingleton<Lazy<IStockTicker>>(() => new Lazy<IStockTicker>(() => container.GetInstace<IStockTicker>()) );
    container.RegisterSingleton<HubContextAdapter<StockTickerHub, IStockTickerHubClient>>();
    container.RegisterSingleton(() => new Lazy<IConnectionManager>(() => GlobalHost.ConnectionManager));
    container.Verify();
