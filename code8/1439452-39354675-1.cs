    public static partial class QueryableExtensions()
    {
    	public static IQueryable Distinct(this IQueryable source)
    	{
    		var distinctCall = Expression.Call(
    			typeof(Queryable), "Distinct", new[] { source.ElementType },
    			source.Expression);
    		return source.Provider.CreateQuery(distinctCall);
    	}
    }
