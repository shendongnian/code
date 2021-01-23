	var testScheduler = new TestScheduler();
	var source = testScheduler.CreateColdObservable<string>(
		ReactiveTest.OnNext(TimeSpan.FromSeconds(0.1).Ticks, "one"),
		ReactiveTest.OnCompleted<string>(TimeSpan.FromSeconds(0.2).Ticks));
	var subscription = source.SubscribeOn(testScheduler)
								.Subscribe(
									item => Console.WriteLine(item),
									error => Console.WriteLine(error),
									() => Console.WriteLine("Complete!")
								);
	testScheduler.Start();
	Console.WriteLine("DONE.");
	Console.ReadLine();
