    public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int batchSize)
    {
    	var batch = new List<T>(batchSize);
    
    	foreach (var item in source)
    	{
    		batch.Add(item);
    		if (batch.Count == batchSize)
    		{
    			yield return batch;
    			batch = new List<T>(batchSize);
    		}
    	}
    
    	if (batch.Any())
    	{
    		yield return batch;
    	}
    }
