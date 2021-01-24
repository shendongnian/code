	public void RegisterFuncs(AutoMocker autoMocker, IEnumerable<Type> types)
	{
		var use = typeof(AutoMocker).GetMethods()
			.First(t => t.Name == "Use" && 
						t.GetGenericArguments().First().Name == "TService");
		var get = typeof(AutoMocker).GetMethod("Get");
		foreach (var type in types)
		{
			// _.container.Use<Func<T>>()
			var typedUse = use.MakeGenericMethod(typeof(Func<>).MakeGenericType(type));
	
			// _container.Get<T>()
			var typedGet = get.MakeGenericMethod(type);
			var target = Expression.Constant(autoMocker);
			var call = Expression.Call(target, typedGet);
	
			// () => _container.Get<T>()
			var lambda = Expression.Lambda(call);
	
			// _.container.Use<Func<T>>(() => _container.Get<T>())
			typedUse.Invoke(autoMocker, new object[] { lambda.Compile() });
		}
	}
	
	// Then call with your AutoMocker instance and the interfaces you want to wire up
	var types = typeof(SomeNamespace.ISomeInterface).Assembly.GetExportedTypes()
		.Where(t => t.IsInterface && !t.ContainsGenericParameters);
	RegisterFuncs(yourAutoMocker, types);
