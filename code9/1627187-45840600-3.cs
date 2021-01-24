	var instances = AppDomain.CurrentDomain.GetAssemblies()
		.SelectMany(a => a.GetTypes())
		.Where(t => t.IsClass && typeof(IStartable).IsAssignableFrom(t))
		.Select(t => (IStartable)Activator.CreateInstance(t));
		
	foreach (var instance in instances)
	{
		instance.Start();
	}
