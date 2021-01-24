	var messages = new Stack<int>(new int[] { 1, 2, 3, 4, 5, 6 });
	
	var observable =
		Observable.While<int>(
			() => messages.Count > 0,
			Observable.Defer(() =>
				Observable.FromAsync(() =>
					Task.Run(() => messages.Pop()))));
			
	observable
		.Subscribe(async message =>
		{
		    await Task.Delay(2);
		    Console.WriteLine(message);
		});	
