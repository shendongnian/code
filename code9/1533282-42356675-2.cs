	public void RegisterLazys(AutoMocker autoMocker, IEnumerable<Type> types)
	{
	    var use = typeof(AutoMocker).GetMethods()
	        .First(t => t.Name == "Use" && 
	                    t.GetGenericArguments().First().Name == "TService");
	    var get = typeof(AutoMocker).GetMethod("Get");
	    foreach (var type in types)
	    {
			// Lazy<T>
			var lazyT = typeof(Lazy<>).MakeGenericType(type);
			
	        // _.container.Use<Lazy<T>>()
	        var typedUse = use.MakeGenericMethod(lazyT);
	
	        // _container.Get<T>()
	        var typedGet = get.MakeGenericMethod(type);
	        var target = Expression.Constant(autoMocker);
	        var call = Expression.Call(target, typedGet);
	
	        // () => _container.Get<T>()
	        var lambda = Expression.Lambda(call);
	
			// _.container.Use<Lazy<T>>(new Lazy<T>(() => _container.Get<T>()));
			typedUse.Invoke(autoMocker, new object[] { Activator.CreateInstance(lazyT, lambda.Compile()) });
		}
	}
