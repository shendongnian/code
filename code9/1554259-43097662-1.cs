    public static async Task<PagedResults<T>> ToPagedResults<T>(this IQueryable<T> source)
    {
    	var documentQuery = source.AsDocumentQuery();
    	var results = new PagedResults<T>();
    	try
    	{
		    var queryResult = await documentQuery.ExecuteNextAsync<T>();
		    if (!queryResult.Any())
		    {
    			return results;
		    }
		    results.ContinuationToken = queryResult.ResponseContinuation;
		    results.Results.AddRange(queryResult);
	    }
	    catch
	    {
    		//documentQuery.ExecuteNextAsync throws an Exception if there are no results
		    return results;
	    }
    
    	return results;
    }
