	var query = ImagesInFolder(Scheduler.Default);
	
	query.Subscribe(x => { Thread.Sleep(1000); Console.WriteLine("A"); });
	query.Subscribe(x => { Thread.Sleep(1000); Console.WriteLine("B"); });
	query.Subscribe(x => { Thread.Sleep(1000); Console.WriteLine("C"); });
	
	Thread.Sleep(10000);
	
	query.Subscribe(x => { Thread.Sleep(1000); Console.WriteLine("D"); });
