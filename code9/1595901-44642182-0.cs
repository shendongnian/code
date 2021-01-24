	var query = Observable.Create<TcpClient>(o =>
	{
		var home = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2323);
		var listener = new TcpListener(home);
		listener.Start();
		return
			Observable
				.Defer(() => Observable.FromAsync(() => listener.AcceptTcpClientAsync()))
				.Repeat()
				.Subscribe(o);
	});
	var completer = new Subject<Unit>();
	var subscription =
		query
			.TakeUntil(completer)
			.Subscribe(
				onNext: c => Console.WriteLine($"{c.Client.RemoteEndPoint} connected"),
				onError: e => Console.WriteLine($"Error: {e.Message}"),
				onCompleted: () => Console.WriteLine("Complete"));
	Console.WriteLine("Enter to cancel");
	Console.ReadLine();
	completer.OnNext(Unit.Default);
	Thread.Sleep(1000);
