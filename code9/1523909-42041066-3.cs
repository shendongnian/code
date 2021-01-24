    public static Expression Wrap(this Expression source)
    {
    	if (source.Type.IsValueType)
    		return Expression.Convert(source, typeof(object));
    	return source;
    }
    
    public static LambdaExpression Unwrap<T>(this Expression<Func<T, object>> source)
    {
    	var body = source.Body;
    	if (body.NodeType == ExpressionType.Convert)
    		body = ((UnaryExpression)body).Operand;
    	return Expression.Lambda(body, source.Parameters);
    }
