    public static class QueryableExtensions
    {
    	public static IQueryable<T> WhereContainsAll<T>(
    		this IQueryable<T> source, 
    		IEnumerable<string> values,
    		params Expression<Func<T, string>>[] members)
    	{
    		var parameter = Expression.Parameter(typeof(T), "r");
    		var body = values
    			.Select(value => members
    				.Select(member => (Expression)Expression.Call(
    					Expression.MakeMemberAccess(parameter, ((MemberExpression)member.Body).Member),
    					"Contains", Type.EmptyTypes, Expression.Constant(value)))
    				.Aggregate(Expression.OrElse))
    			.Aggregate(Expression.AndAlso);
    		var predicate = Expression.Lambda<Func<T, bool>>(body, parameter);
    		return source.Where(predicate);
    	}
    }
