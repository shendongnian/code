    public static class SelectorFactory
    {    
    	public static Func<object, object> GetSelector(Type type, string memberPath)
    	{
    		return CreateSelector(type, memberPath);
    	}
    
    	static Func<object, object> CreateSelector(Type type, string memberPath)
    	{
    		var parameter = Expression.Parameter(typeof(object), "source");
    		var source = Expression.Convert(parameter, type);
    		var value = memberPath.Split('.').Aggregate(
    			(Expression)source, Expression.PropertyOrField);
    		if (value.Type.IsValueType)
    			value = Expression.Convert(value, typeof(object));
    		// (object source) => (object)((T)source).Prop1.Prop2...PropN
    		var selector = Expression.Lambda<Func<object, object>>(value, parameter);
    		return selector.Compile();
    	}
    }
