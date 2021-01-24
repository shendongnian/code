	public static class QueryableExtensions
	{
		public static IReadOnlyCollection<TResult> GetDistinctValuesForProperty<T, TResult>(this IQueryable<T> query, Expression<Func<T, TResult>> propertyAccess)
		{
			return SelectDistinct(query, propertyAccess).ToList();
		}
	
		public static IReadOnlyCollection<object> GetDistinctValuesForProperty<TSource>(this IQueryable<TSource> query, string propertyName)
		{
			var unboundFuncType = typeof(Func<,>);
			var unboundExprType = typeof(Expression<>);
			
			var sourceType = typeof(TSource); // TSource
			
			var resultType = typeof(TSource)
				.GetProperty(propertyName)
				.PropertyType; // TResult
			
			// Func<TSource, TResult>
			var funcType = unboundFuncType.MakeGenericType(new [] { sourceType, resultType });
			
			// Expression<Func<TSource, TResult>>
			var expressionType = unboundExprType.MakeGenericType(new [] { funcType });
	
			// Instance of Expression<Func<TSource, TResult>>, for example x => x.Name
			var propertyAccess = typeof(StringExtensions)
				.GetMethod(nameof(StringExtensions.AsPropertyExpression), new[] { typeof(string) })
				.MakeGenericMethod(new [] { sourceType, resultType })
				.Invoke(null, new object[] { propertyName });
			
			// SelectDistinct query transform
			var selectDistinctMethod = typeof(QueryableExtensions)
				.GetMethod(nameof(QueryableExtensions.SelectDistinct), BindingFlags.NonPublic | BindingFlags.Static)
				.MakeGenericMethod(new [] { sourceType, resultType });
	        // IQueryable<TSource> ==> IQueryable<TResult>
			var result = selectDistinctMethod.Invoke(null, new object[] { query, propertyAccess });
	
			// Cast to object via IEnumerable and convert to list
			return ((IEnumerable)result).Cast<object>().ToList();
		}
	
		private static IQueryable<TResult> SelectDistinct<TSource, TResult>(this IQueryable<TSource> query, Expression<Func<TSource, TResult>> propertyAccess)
		{
			return query.Select(propertyAccess).Distinct();
		}
	}
	
	public static class StringExtensions
	{
		public static Expression<Func<T, TResult>> AsPropertyExpression<T, TResult>(this string propertyName)
		{
			var parameter = Expression.Parameter(typeof(T), "x");
			var property = typeof(T).GetProperty(propertyName);
			var body = Expression.MakeMemberAccess(parameter, property);
			return Expression.Lambda<Func<T, TResult>>(body, parameter);
		}
	}
