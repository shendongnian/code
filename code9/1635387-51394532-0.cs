	public static async Task WhenAllOneByOne<T>(this IEnumerable<T> source, Func<T, Task> process)
	{
		foreach (var item in source)
			await process(item);
	}
	public static async Task<List<U>> WhenAllOneByOne<T, U>(this IEnumerable<T> source, Func<T, Task<U>> transform)
	{
		var results = new List<U>();
		foreach (var item in source)
			results.Add(await transform(item));
		return results;
		// I would use yield return but unfortunately it is not supported in async methods
	}
