	var aSources = new Subject<Tuple<string, Subject<string>>>();
	var bHeartbeat = Observable.Interval(TimeSpan.FromSeconds(1)).Publish().RefCount();
	var stateObservable = aSources.SelectMany(t =>
			Observable.Merge(
				t.Item2.Select(_ => new Func<int, int>(i => 0)),
				bHeartbeat.Select(_ => new Func<int, int>(i => i + 1))
			)
			.Scan(0, (state, func) => func(state))
			.Where(state => state >= 2)
			.Take(1)
			.Select(_ => t.Item1)
		);
	stateObservable.Subscribe(s => Console.WriteLine($"{s} is kidnapped"));
	aSources
		.SelectMany(t => t.Item2.Select(s => Tuple.Create(t.Item1, s)))
		.Subscribe(t => Console.WriteLine($"{t.Item1} says '{t.Item2}'"));
	bHeartbeat.Subscribe(_ => Console.WriteLine("**Heartbeat**"));
	var a = new Subject<string>();
	var c = new Subject<string>();
	var d = new Subject<string>();
	var e = new Subject<string>();
	var f = new Subject<string>();
	
	aSources.OnNext(Tuple.Create("A", a));
	aSources.OnNext(Tuple.Create("C", c));
	aSources.OnNext(Tuple.Create("D", d));
	aSources.OnNext(Tuple.Create("E", e));
	aSources.OnNext(Tuple.Create("F", f));
	a.OnNext("Hello");
	c.OnNext("My name is C");
	d.OnNext("D is for Dog");
	await Task.Delay(TimeSpan.FromMilliseconds(1200));
	e.OnNext("Easy-E here");
	a.OnNext("A is for Apple");
	await Task.Delay(TimeSpan.FromMilliseconds(2200));
