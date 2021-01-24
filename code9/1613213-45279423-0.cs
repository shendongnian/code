    public static partial class QueryableExtensions
    {
    	public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, Expression<Func<T, object>> keySelector)
    	{
    		return source.OrderBy(keySelector, "OrderBy");
    	}
    	public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, Expression<Func<T, object>> keySelector)
    	{
    		return source.OrderBy(keySelector, "OrderByDescending");
    	}
    	public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, Expression<Func<T, object>> keySelector)
    	{
    		return source.OrderBy(keySelector, "ThenBy");
    	}
    	public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, Expression<Func<T, object>> keySelector)
    	{
    		return source.OrderBy(keySelector, "ThenByDescending");
    	}
    	private static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, Expression<Func<T, object>> keySelector, string method)
    	{
    		var parameter = keySelector.Parameters[0];
    		var body = keySelector.Body;
    		if (body.NodeType == ExpressionType.Convert)
    			body = ((UnaryExpression)body).Operand;
    		var selector = Expression.Lambda(body, parameter);
    		var methodCall = Expression.Call(
    			typeof(Queryable), method, new[] { parameter.Type, body.Type },
    			source.Expression, Expression.Quote(selector));
    		return (IOrderedQueryable<T>)source.Provider.CreateQuery(methodCall);
    	}
    }
