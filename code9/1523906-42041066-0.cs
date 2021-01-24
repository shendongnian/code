    public static Expression Wrap(this Expression source)
    {
    	if (source.Type.IsValueType)
    		return Expression.Convert(source, typeof(object));
    	return source;
    }
    
    public static LambdaExpression Unwrap<T>(this Expression<Func<T, object>> source)
    {
    	if (source.Body.NodeType == ExpressionType.Convert)
    	{
    		var operand = ((UnaryExpression)source.Body).Operand;
    		if (operand.Type.IsValueType)
    			return Expression.Lambda(operand, source.Parameters);
    	}
    	return source;
    }
