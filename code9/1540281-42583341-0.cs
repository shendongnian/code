	var sw = Stopwatch.StartNew();
	var subject = new Subject<int>();
	var o2 = subject.Where(i => i % 2 == 0).ToList();
	var o3 = subject.Where(i => i % 3 == 0).ToList();
	var o4 = subject.Where(i => i % 4 == 0).ToList();
	
	var c = Observable.Concat(o2, o3, o4)
	//		.Replay()
	//		.RefCount() 
	//.Replay().RefCount() has no impact here.
		;
	c.Subscribe(
		x => Console.WriteLine("Event raised [Values: {0}, Timestamp: {1}]", string.Join("|", x), sw.Elapsed),
		() => Console.WriteLine("Subcription closed"));
	for(int i = 0; i < 6; i++)
		subject.OnNext(i);
	subject.OnCompleted();
