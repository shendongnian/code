	private static IList<Type> _entityTypeCache;
	private static IList<Type> GetEntityTypes(Type type)
	{
		if (_entityTypeCache != null && _entityTypeCache.First().BaseType == type)
		{
			return _entityTypeCache.ToList();
		}
		_entityTypeCache = (from a in GetReferencingAssemblies()
							from t in a.DefinedTypes
							where t.BaseType == type
							select t.AsType()).ToList();
		return _entityTypeCache;
	}
	private static IEnumerable<Assembly> GetReferencingAssemblies()
	{
		var assemblies = new List<Assembly>();
		var dependencies = DependencyContext.Default.RuntimeLibraries;
		foreach (var library in dependencies)
		{
			try
			{
				var assembly = Assembly.Load(new AssemblyName(library.Name));
				assemblies.Add(assembly);
			}
			catch (FileNotFoundException)
			{ }
		}
		return assemblies;
	}
