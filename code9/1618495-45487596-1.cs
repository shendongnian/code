    Type TypeOfAddition<TLeft, TRight>()
    {
    	object GetDefault<T>()
    	{
    		if (typeof(T).IsValueType)
    		{
    			return default(T);
    		}
    
    		if (typeof(T) == typeof(string))
    		{
    			return string.Empty;
    		}
    	
    		return (T)Activator.CreateInstance(typeof(T));
    	}
    
    	var binder = Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(
    		CSharpBinderFlags.None,
    		ExpressionType.Add,
    		null,
    		new CSharpArgumentInfo[] {
    			CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
    			CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
    		}
    	);
    
    	var left = Expression.Parameter(typeof(TLeft));
    	var right = Expression.Parameter(typeof(TRight));
    
    	var func = Expression.Lambda(
    		Expression.Dynamic(binder, typeof(object), left, right),
    		new[] { left, right }
    	).Compile();
    
    	return func
    		.DynamicInvoke(GetDefault<TLeft>(), GetDefault<TRight>())
    		?.GetType() ?? typeof(object);
    }
