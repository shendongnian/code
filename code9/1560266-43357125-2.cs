	public static IObservable<TResult> SelectAsync<TSource, TResult>(
		this IObservable<TSource> src,
		Func<TSource, Task<TResult>> selectorAsync)
	{
		// using local variable for counter is easier than src.Scan(...)
		var counter = 0;
		var streamOfTasks =
			from source in src
			from result in Observable.FromAsync(async () => new
			{
				Index = Interlocked.Increment(ref counter) - 1,
				Result = await selectorAsync(source)
			})
			select result;
		// buffer the results coming out of order
		return Observable.Create<TResult>(observer =>
		{
			var index = 0;
			var buffer = new Dictionary<int, TResult>();
			return streamOfTasks.Subscribe(item =>
			{
				buffer.Add(item.Index, item.Result);
				TResult result;
				while (buffer.TryGetValue(index, out result))
				{
					buffer.Remove(index);
					observer.OnNext(result);
					index++;
				}
			});
		});
	}
