	var emitter = new Subject<string>();
	emitter.OnNext("one");
	emitter.OnCompleted();
	var subscription = emitter
								.Subscribe(
									item => Console.WriteLine(item),
									error => Console.WriteLine(error),
									() => Console.WriteLine("Complete!")
								);
	
	Console.WriteLine("DONE.");
	Console.ReadLine();
