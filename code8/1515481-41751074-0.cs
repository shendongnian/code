    public static class EntityUtils
    {
    	public static string GetEntitySetName<T>(this IObjectContextAdapter dbContext) where T : class
    	{
    		return dbContext.ObjectContext.CreateObjectSet<T>().EntitySet.Name;
    	}
    
    	public static ObjectResult<T> ReadSingleResult<T>(this IObjectContextAdapter dbContext, DbDataReader dbReader)
    		where T : class
    	{
    		return dbContext.ObjectContext.Translate<T>(dbReader, dbContext.GetEntitySetName<T>(), MergeOption.AppendOnly);
    	}
    
    	public static void Load<T>(this ObjectResult<T> source) where T : class
    	{
    		// Consume the enumerable by iterating it
    		using (var en = source.GetEnumerator())
    			while (en.MoveNext()) { }
    	}
    }
