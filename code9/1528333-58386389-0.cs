	public void AddTransientsByConvention(IServiceCollection services, Assembly[] assemblies, Func<Type, bool> myPredicate)
	{
		List<Type> interfaces = new List<Type>();
		List<Type> implementations = new List<Type>();
		foreach (var assembly in assemblies)
		{
			interfaces.AddRange(assembly.ExportedTypes.Where(x => x.IsInterface && myPredicate(x)));
			implementations.AddRange(assembly.ExportedTypes.Where(x => !x.IsInterface && !x.IsAbstract && myPredicate(x)));
		}
			
		foreach (var @interface in interfaces)
		{
			var implementation = implementations
				.FirstOrDefault(x => @interface.IsAssignableFrom(x) &&
					$"I{x.Name}" == @interface.Name );
			if (implementation == null)
				throw new Exception($"Couldn't find implementation for interface {@interface}");
			
			services.AddTransient(@interface, implementation);
		}
	}
