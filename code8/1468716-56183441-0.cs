private static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> query, SortField sortField)
{
	var queryParameterExpression = Expression.Parameter(typeof(T), "x");
	var orderByPropertyExpression = GetPropertyExpression(sortField.FieldName, queryParameterExpression);
	Type orderByPropertyType = orderByPropertyExpression.Type;
	LambdaExpression lambdaExpression = Expression.Lambda(orderByPropertyExpression, queryParameterExpression);
	if (orderByPropertyType.IsEnum)
	{
		orderByPropertyType = typeof(int);
		lambdaExpression = GetExpressionForEnumOrdering<T>(lambdaExpression);
	}
	else if (orderByPropertyType == typeof(bool))
	{
		orderByPropertyType = typeof(string);
		lambdaExpression =
			GetExpressionForBoolOrdering(orderByPropertyExpression, queryParameterExpression);
	}
	var orderByExpression = Expression.Call(
		typeof(Queryable),
		sortField.SortDirection == SortDirection.Asc ? "OrderBy" : "OrderByDescending",
		new Type[] { typeof(T), orderByPropertyType },
		query.Expression,
		Expression.Quote(lambdaExpression));
	return query.Provider.CreateQuery<T>(orderByExpression);
}
The shared `GetPropertyExpression` has been simplified a bit, to exclude the nested property handling.
private static MemberExpression GetPropertyExpression(string propertyName, ParameterExpression queryParameterExpression)
{
	MemberExpression result = Expression.Property(queryParameterExpression, propertyName);
	return result;
}
Here is the slightly modified code (from the accepted solution) to handle the `Enum` ordering.
private static Expression<Func<TSource, int>> GetExpressionForEnumOrdering<TSource>(LambdaExpression source)
{
	var enumType = source.Body.Type;
	if (!enumType.IsEnum)
		throw new InvalidOperationException();
	var body = ((int[])Enum.GetValues(enumType))
		.OrderBy(value => GetEnumDescription(value, enumType))
		.Select((value, ordinal) => new { value, ordinal })
		.Reverse()
		.Aggregate((Expression)null, (next, item) => next == null ? (Expression)
			Expression.Constant(item.ordinal) :
			Expression.Condition(
				Expression.Equal(source.Body, Expression.Convert(Expression.Constant(item.value), enumType)),
				Expression.Constant(item.ordinal),
				next));
	return Expression.Lambda<Func<TSource, int>>(body, source.Parameters[0]);
}
And the `boolean` ordering as well.
private static LambdaExpression GetExpressionForBoolOrdering(MemberExpression orderByPropertyExpression, ParameterExpression queryParameterExpression)
{
	var firstWhenActiveExpression = Expression.Condition(orderByPropertyExpression,
		Expression.Constant("A"),
		Expression.Constant("Z"));
	return Expression.Lambda(firstWhenActiveExpression, new[] { queryParameterExpression });
}
Also the `GetEnumDescription` has been modified to receive the `Type` as the parameter, so it can be called without a generic.
private static string GetEnumDescription(int value, Type enumType)
{
	if (!enumType.IsEnum)
		throw new InvalidOperationException();
	var name = Enum.GetName(enumType, value);
	var field = enumType.GetField(name, BindingFlags.Static | BindingFlags.Public);
	return field.GetCustomAttribute<DescriptionAttribute>()?.Description ?? name;
}
The `SortField` is a simple abstraction containing the `string` column property to be sorted upon and the `direction` of the sort. For the sake of simplicity I am also not sharing that one here. 
Cheers!
