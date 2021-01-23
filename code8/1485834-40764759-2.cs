    public Expression<Func<Entity, object>> create (string property)
    {
    	var parameter = Expression.Parameter(typeof(Entity));
    	var memberExpression = Expression.Property(parameter, property);
    	Expression convertExpr = Expression.Convert(memberExpression, typeof(object));
    	var expression = Expression.Lambda(convertExpr, parameter);	
    
    	return (Expression<Func<Entity, object>>)expression;
    }
