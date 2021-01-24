	public static IEnumerable<TResult> Select<TSource, TResult>(
        this ICollection<TSource> source, 
        Func<TSource, TResult> selector, 
        Action<SelectProgress> timeRemaining)
	{
		Stopwatch timer = new Stopwatch();
		timer.Start();
		var counter = 0;
		foreach (var element in source)
		{
			yield return selector(element);
			counter++;
			timeRemaining?.Invoke(new SelectProgress
			{
				Percentage = counter/(decimal)source.Count,
				TimeTaken = timer.Elapsed,
				EstimatedTotalTime = 
                    TimeSpan.FromTicks(timer.Elapsed.Ticks/counter * source.Count)
			});
		}
	}
