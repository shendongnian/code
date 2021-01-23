    public static class TaskExtensions
    {
    	public static async Task<Task<TResult>> WhenAnyWithPredicate<TResult>(Func<Task<TResult>, bool> predicate, params Task<TResult>[] tasks)
    	{
			if (tasks == null)
		    {
			    throw new ArgumentNullException();
		    }
	
		    if (tasks.Length == 0)
		    {
		    	return null;	
		    }
    		// Make a safe copy (in case the original array is modified while we are awaiting).
    		tasks = tasks.ToArray();
    		
    		// Await the first task.
    		var result = await Task.WhenAny(tasks);
    
    		// Test the task and await the next task if necessary.
    		while (tasks.Length > 0 && !predicate(result))
    		{
    			tasks = tasks.Where(x => x != result).ToArray();
    			if (tasks.Length == 0)
    			{
    				result = null;
    			}
    			else
    			{
    				result = await Task.WhenAny(tasks);
    			}
    		}
    		
    		// Return the result.
    		return result;
    	}
    }
