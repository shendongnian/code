    public static partial class QueryableExtensions
    {
    	public static IQueryable<T> WhereIn<T, V>(this IQueryable<T> source, Expression<Func<T, V>> valueSelector, params V[] values)
    	{
    		var condition = Expression.Call(
    			typeof(Enumerable), "Contains",	new[] { typeof(V) },
    			Expression.Constant(values), valueSelector.Body);
    		var predicate = Expression.Lambda<Func<T, bool>>(condition, valueSelector.Parameters);
    		return source.Where(predicate);
    	}
    }
