    public static class QueryableExtensions
    {
    	public static IQueryable BindDbFunctions(this IQueryable source)
    	{
    		var expression = new DbFunctionsBinder().Visit(source.Expression);
    		if (expression == source.Expression) return source;
    		return source.Provider.CreateQuery(expression);
    	}
    
    	class DbFunctionsBinder : ExpressionVisitor
    	{
    		protected override Expression VisitMethodCall(MethodCallExpression node)
    		{
    			if (node.Object != null && node.Object.Type == typeof(DateTime))
    			{
    				if (node.Method.Name == "AddHours")
    				{
    					var timeValue = Visit(node.Object);
    					var addValue = Visit(node.Arguments.Single());
    					if (timeValue.Type != typeof(DateTime?)) timeValue = Expression.Convert(timeValue, typeof(DateTime?));
    					if (addValue.Type != typeof(int?)) addValue = Expression.Convert(addValue, typeof(int?));
    					var methodCall = Expression.Call(
    						typeof(DbFunctions), "AddHours", Type.EmptyTypes,
    						timeValue, addValue);
    					return Expression.Convert(methodCall, typeof(DateTime));
    				}
    			}
    			return base.VisitMethodCall(node);
    		}
    	}
    }
