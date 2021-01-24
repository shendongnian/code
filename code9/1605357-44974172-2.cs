    public static IQueryable WhereLike(this IQueryable source, string propertyName, 
        string pattern)
	{
		if (source == null) throw new ArgumentNullException("source");
		if (propertyName == null) throw new ArgumentNullException("propertyName");
		var a = Expression.Parameter(source.GetType().GetGenericArguments().First(), "a");
		var prop = Expression.PropertyOrField(a, propertyName);
		var expr = Expression.Call(
				typeof(SqlMethods), "Like",
				null,
				prop, Expression.Constant(pattern));
		MethodCallExpression whereCallExpression = Expression.Call(
				typeof(Queryable),
				"Where",
				new Type[] { source.ElementType },
				source.Expression,
				Expression.Lambda(expr, a));
		return source.Provider.CreateQuery(whereCallExpression);
	}
