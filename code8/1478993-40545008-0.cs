    public static partial class EFExtensions
    {
    	public static IOrderedQueryable<T> SortBy<T>(this IQueryable<T> source, Expression<Func<T, object>> keySelector)
    	{
    		var body = keySelector.Body;
    		if (body.NodeType == ExpressionType.Convert)
    			body = ((UnaryExpression)keySelector.Body).Operand;
    		var selector = Expression.Lambda(body, keySelector.Parameters);
    		var orderByCall = Expression.Call(
    			typeof(Queryable), "OrderBy", new[] { typeof(T), body.Type },
    			source.Expression, Expression.Quote(selector));
    		return (IOrderedQueryable<T>)source.Provider.CreateQuery(orderByCall);
    	}
    }
