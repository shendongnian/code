	public static IQueryable<T> Where<T>(this IQueryable<T> query, string selector, string comparer, string value)
	{
		var target = Expression.Parameter(typeof(T));
		return query.Provider.CreateQuery<T>(CreateWhereClause(target, query.Expression, selector, comparer, value));
	}
