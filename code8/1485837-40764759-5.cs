    public static class EntityExtensions
    {
    	public static Expression<Func<object>> ToExpression(this Entity entity, string property)
    	{
    		var constant = Expression.Constant(entity);
    		var memberExpression = Expression.Property(constant, property);		
    		Expression convertExpr = Expression.Convert(memberExpression, typeof(object));
    		var expression = Expression.Lambda(convertExpr);
    
    		return (Expression<Func<object>>)expression;
    	}
    }
