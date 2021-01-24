    public static Action<TSource, TTarget> BuildMapAction<TSource, TTarget>(IEnumerable<PropertyMap> properties)
    {
    	var source = Expression.Parameter(typeof(TSource), "source");
    	var target = Expression.Parameter(typeof(TTarget), "target");
    
    	var statements = new List<Expression>();
    	foreach (var propertyInfo in properties)
    	{
    		var sourceProperty = Expression.Property(source, propertyInfo.SourceProperty);
    		var targetProperty = Expression.Property(target, propertyInfo.TargetProperty);
    		Expression value = sourceProperty;
    		if (value.Type != targetProperty.Type)
    			value = Expression.Convert(value, targetProperty.Type);
    		Expression statement = Expression.Assign(targetProperty, value);
    		// for class/interface or nullable type
    		if (!sourceProperty.Type.IsValueType || Nullable.GetUnderlyingType(sourceProperty.Type) != null)
    		{
    			var valueNotNull = Expression.NotEqual(sourceProperty, Expression.Constant(null, sourceProperty.Type));
    			statement = Expression.IfThen(valueNotNull, statement);
    		}
    		statements.Add(statement);
    	}
    
    	var body = statements.Count == 1 ? statements[0] : Expression.Block(statements);
    	// for class.interface type
    	if (!source.Type.IsValueType)
    	{
    		var sourceNotNull = Expression.NotEqual(source, Expression.Constant(null, source.Type));
    		body = Expression.IfThen(sourceNotNull, body);
    	}
    
    	// not sure about the need of this
    	if (body.CanReduce)
    		body = body.ReduceAndCheck();
    	body = body.ReduceExtensions();
    
    	var lambda = Expression.Lambda<Action<TSource, TTarget>>(body, source, target);
    
    	return lambda.Compile();
    }
