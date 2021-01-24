    /// <summary>
    /// Gets the first result
    /// </summary>
    /// <typeparam name="T">Type of the Class</typeparam>
    /// <param name="source">Queryable to take one from</param>
    /// <returns></returns>
    public static T TakeOne<T>(this IQueryable<T> source)
    {
    	var documentQuery = source.AsDocumentQuery();            
    	if (documentQuery.HasMoreResults)
    	{
		    var queryResult = documentQuery.ExecuteNextAsync<T>().Result;
		    if (queryResult.Any())
		    {
    			return queryResult.Single<T>();
		    }
	    }
	    return default(T);
    }
