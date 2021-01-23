    void Main()
    {
    	var res = Containers.OtherGrouping(c => c.ContainerID);
    	res.Expression.Dump();
    	res.Dump();
    }
    
    public static class Extensions
    {
    	public static IQueryable<IGrouping<TKey, TSource>> OtherGrouping<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector)
    	{
    		return source.Provider.CreateQuery<IGrouping<TKey, TSource>>(
    			source.GroupBy(keySelector).Expression
    		);
    	}
    }
