    ParameterExpression attributeParameter = Expression.Parameter(typeof(User), "user");
    MemberExpression attribute = Expression.Property(attributeParameter, attributeName);
    BinaryExpression nullCheck = Expression.NotEqual(attribute, Expression.Constant(null, typeof(object)));
    BinaryExpression condition = null;
    
     switch (policyOperator)
    {
    	case Operator.GreaterThanOrEqual:
    	if (Value.GetType() != typeof(string))
    		condition = Expression.GreaterThanOrEqual(Expression.Call(parseMethod, 
    						Expression.Property(attributeParameter, attributeName)), 
    							Expression.Constant(Value));
    	
    	.
    	.
    }
    
    return Expression.Lambda<Func<User, bool>>(Expression.AndAlso(nullCheck, condition), attributeParameter);							
