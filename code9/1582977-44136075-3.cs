    public IObservable<T> Prioritize<T>(params IObservable<T>[] orderedByDescendingPriority)
    {
    	return orderedByDescendingPriority
    		.Select((o, i) => o.Select(item => Tuple.Create(orderedByDescendingPriority.Length - i, item)))
    		.Merge()
    		.Select(t => new Func<Tuple<int, T, bool>, Tuple<int, T, bool>>(t2 => Tuple.Create(Math.Max(t2.Item1, t.Item1), t.Item2, t.Item1 >= t2.Item1)))
    		.Scan(Tuple.Create(0, default(T), false), (t, f) => f(t))
    		.Where(t => t.Item3)
    		.Select(t => t.Item2);
    }
	var merged = Prioritize(
		GetFromWeb().ToObservable(),
		GetFromDisk().ToObservable()
	);
