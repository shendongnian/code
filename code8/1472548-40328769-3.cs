    public static class QueryableExtensions
    {
    	public static IQueryable<T> WhereAny<T, E>(this IQueryable<T> source, Expression<Func<T, IEnumerable<E>>> elements, Expression<Func<E, bool>> predicate)
    	{
    		var body = Expression.Call(
    			typeof(Enumerable), "Any", new Type[] { typeof(E) },
    			elements.Body, predicate);
    		return source.Where(Expression.Lambda<Func<T, bool>>(body, elements.Parameters));
    	}
    }
