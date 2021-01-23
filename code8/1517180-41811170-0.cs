    // Automatically discover and register all message handlers...
    services.Scan(
    	x =>
    		{
    			var entryAssembly = Assembly.GetEntryAssembly();
    			var referencedAssemblies = entryAssembly.GetReferencedAssemblies().Select(Assembly.Load);
    			var assemblies = new List<Assembly> { entryAssembly }.Concat(referencedAssemblies);
    
    			x.FromAssemblies(assemblies)
    				.AddClasses(classes => classes.AssignableTo(typeof(IEventHandler<>)))
    					.AsImplementedInterfaces()
    					.WithScopedLifetime();
    		});
