    async Task ProcessAllItems<T>(IEnumerable<T> items,
    	Func<T, Task<bool>> checkItem, // an async callback
    	Func<T, Task> processItem)
    {
    	List<Task> checkTasks = items
    		.Select(i => checkItem(i)
    		.ContinueWith(_ =>
    		{
    			if (_.Result)
    				return processItem(i);
    			return null;
    		}).Unwrap())   // .Unwrap takes the inner task of a Task<Task<>>
    		.ToList();     // when making collections of tasks ALWAYS materialize with ToList or ToArray to avoid accudental multiple executions
    
    	await Task.WhenAll(checkTasks);
    
    }
