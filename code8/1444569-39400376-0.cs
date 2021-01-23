    static Func<T, object> CreateSelector<T>(IEnumerable<string> propertyNames)
    {
    	var sourceType = typeof(T);
    	var parameter = Expression.Parameter(sourceType, "e");
    	var properties = propertyNames.Select(name => Expression.PropertyOrField(parameter, name)).ToArray();
    	var selector = Expression.Lambda<Func<T, object>>(
    		Expression.Call(typeof(Tuple), "Create", properties.Select(p => p.Type).ToArray(), properties),
    		parameter);
    	return selector.Compile();
    }
