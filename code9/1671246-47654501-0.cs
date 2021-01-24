    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		var implementedConfigTypes = Assembly.GetExecutingAssembly()
			.GetTypes()
			.Where(t => !t.IsAbstract
				&& !t.IsGenericTypeDefinition
				&& t.GetTypeInfo().ImplementedInterfaces.Any(i =>
					i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
			
		foreach (var configType in implementedConfigTypes)
		{
			dynamic config = Activator.CreateInstance(configType);
			modelBuilder.ApplyConfiguration(config);
		}
	}
