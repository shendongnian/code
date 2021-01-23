    public static class QueryableExtensions
    {
    	public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, Expression<Func<T, object>> keySelector, bool ascending)
    	{
    		var selectorBody = keySelector.Body;
    		// Strip the Convert expression
    		if (selectorBody.NodeType == ExpressionType.Convert)
    			selectorBody = ((UnaryExpression)selectorBody).Operand;
    		// Create dynamic lambda expression
    		var selector = Expression.Lambda(selectorBody, keySelector.Parameters);
    		// Generate the corresponding Queryable method call
    		var queryBody = Expression.Call(typeof(Queryable),
    			ascending ? "OrderBy" : "OrderByDescending",
    			new Type[] { typeof(T), selectorBody.Type },
    			source.Expression, Expression.Quote(selector));
    		return source.Provider.CreateQuery<T>(queryBody); 
    	}
    }
