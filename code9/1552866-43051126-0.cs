	public static IObservable<List<T>> BackBuffer<T>(this IObservable<T> source, TimeSpan ts)
	{
		return BackBuffer(source, ts, Scheduler.Default);
	}
    public static IObservable<List<T>> BackBuffer<T>(this IObservable<T> source, TimeSpan ts, IScheduler scheduler)
	{
		return source
			.Timestamp()
			.Scan(new List<Timestamped<T>>(), (list, element) => list
				.Where(ti => scheduler.Now - ti.Timestamp <= ts)
				.Concat(Enumerable.Repeat(element, 1))
				.ToList()
			)
			.Select(list => list.Select(t => t.Value).ToList());
	}
