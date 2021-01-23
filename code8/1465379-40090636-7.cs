	static Expression CreateWhereClause(ParameterExpression target, Expression expression, string selector, string comparer, string value)
	{
		var predicate = Expression.Lambda(CreateComparison(target, selector, comparer, value), target);
		return Expression.Call(typeof(Queryable), nameof(Queryable.Where), new[] { target.Type },
			expression, Expression.Quote(predicate));
	}
