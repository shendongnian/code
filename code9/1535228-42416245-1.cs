    public static partial class QueryableExtensions
    {
    	public static IQueryable<T> WhereIn<T, V>(this IQueryable<T> source, Expression<Func<T, V>> valueSelector, IEnumerable<V> values)
    	{
    		var condition = values
    			.Select(value => Expression.Equal(valueSelector.Body, Expression.Constant(value)))
    			.DefaultIfEmpty()
    			.Aggregate(Expression.OrElse);
    		if (condition == null) return source;
    		var predicate = Expression.Lambda<Func<T, bool>>(condition, valueSelector.Parameters);
    		return source.Where(predicate);
    	}
    }
