    protected override void OnStartup(StartupEventArgs e)
    {
        var builder = new ContainerBuilder();
		builder.RegisterType<Cleaner>().As<ICleaner>();
		builder.RegisterType<Repository>().AsImplementedInterfaces().InstancePerLifetimeScope();
		
		// Add the MainWindowclass and later resolve
		build.RegisterType<MainWindow>().AsSelf();
		var container = builder.Build();
    
    	using (var scope = container.BeginLifetimeScope())
    	{
    		var window = scope.Resolve<MainWindow>();
    		window.Show();
    	}
    }
