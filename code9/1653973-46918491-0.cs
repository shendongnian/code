    public static class QueryableExtensions
    {
    	public static IOrderedQueryable<TOuter> OrderBy<TOuter, TInner, TKey>(
    		this IQueryable<TOuter> source,
    		Expression<Func<TOuter, IEnumerable<TInner>>> innerCollectionSelector,
    		Expression<Func<TInner, TKey>> keySelector,
    		bool ascending)
    	{
    		return source.OrderBy(innerCollectionSelector, keySelector, ascending, false);
    	}
    
    	public static IOrderedQueryable<TOuter> ThenBy<TOuter, TInner, TKey>(
    		this IOrderedQueryable<TOuter> source,
    		Expression<Func<TOuter, IEnumerable<TInner>>> innerCollectionSelector,
    		Expression<Func<TInner, TKey>> keySelector,
    		bool ascending)
    	{
    		return source.OrderBy(innerCollectionSelector, keySelector, ascending, true);
    	}
    
    	static IOrderedQueryable<TOuter> OrderBy<TOuter, TInner, TKey>(
    		this IQueryable<TOuter> source,
    		Expression<Func<TOuter, IEnumerable<TInner>>> innerCollectionSelector,
    		Expression<Func<TInner, TKey>> innerKeySelector,
    		bool ascending, bool concat)
    	{
    		var parameter = innerCollectionSelector.Parameters[0];
    		var innerOrderByMethod = ascending ? "OrderBy" : "OrderByDescending";
    		var innerOrderByCall = Expression.Call(
    			typeof(Enumerable), innerOrderByMethod, new[] { typeof(TInner), typeof(TKey) },
    			innerCollectionSelector.Body, innerKeySelector);
    		var innerSelectCall = Expression.Call(
    			typeof(Enumerable), "Select", new[] { typeof(TInner), typeof(TKey) },
    			innerOrderByCall, innerKeySelector);
    		var innerFirstOrDefaultCall = Expression.Call(
    			typeof(Enumerable), "FirstOrDefault", new[] { typeof(TKey) },
    			innerSelectCall);
    		var outerKeySelector = Expression.Lambda(innerFirstOrDefaultCall, parameter);
    		var outerOrderByMethod = concat ? ascending ? "ThenBy" : "ThenByDescending" : innerOrderByMethod;
    		var outerOrderByCall = Expression.Call(
    			typeof(Queryable), outerOrderByMethod, new[] { typeof(TOuter), typeof(TKey) },
    			source.Expression, Expression.Quote(outerKeySelector));
    		return (IOrderedQueryable<TOuter>)source.Provider.CreateQuery(outerOrderByCall);
    	}
    }
