	IObservable<int> source = Observable.Range(1, 10);
	IObserver<int> observer = Observer.Create<int>(
	    x => Console.WriteLine("OnNext: {0}", x),
	    ex => Console.WriteLine("OnError: {0}", ex.Message),
		() => Console.WriteLine("OnCompleted"));		
	IDisposable subscription = source.Subscribe(observer);
	Console.WriteLine("Press ENTER to unsubscribe...");
	Console.ReadLine();
	subscription.Dispose();
