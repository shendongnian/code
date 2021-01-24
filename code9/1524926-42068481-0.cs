	var numbers = Enumerable.Range(1,6);
	var resultSync = await Enumerable.Range(1,6).SelectAsync(Inc);
	var resultAsync = await Enumerable.Range(1,100).SelectAsync(IncAsync);
	
	Console.WriteLine("sync" + string.Join(",", resultSync));
	Console.WriteLine("async" + string.Join(",", resultAsync));
    	
    static class IEnumerableTasks
    {
    	public static Task<TResult[]> SelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> func)
    	{
    		return Task.WhenAll( source.Select(async n => await Task.Run(()=> func(n))));
    	}
    	
    	public static Task<TResult[]> SelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> func)
    	{
    		return Task.WhenAll(source.Select(func));
    	}
    }
	static int Inc(int input) 
	{ 
		Task.Delay(1000).Wait();
		return input+1;
	}
	
	static async Task<int> IncAsync(int input)
	{
		await Task.Delay(1000);
		return input + 1;
	}
