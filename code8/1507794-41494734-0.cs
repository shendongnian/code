    public static MethodInfo MethodOf(Expression<Action> expression)
    {
    	MethodCallExpression body = (MethodCallExpression)expression.Body;
    	return body.Method;
    }
    
    public static bool MethodHasAttribute(Expression<Action> expression, Type attributeType)
    {
    	var method = MethodOf(expression);
    
    	const bool includeInherited = false;
    	return method.GetCustomAttributes(attributeType, includeInherited).Any();
    }
