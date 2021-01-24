	IDisposable subscription =
		BootstrapNodes
			.ToObservable()
			.Select(node =>
				Observable
					.Start(() =>
					{
						Console.WriteLine(String.Format("Currently bootstrapping {0} on {1}",
						node.NodeName,
						node.IPAddress));
						ChefServer.BootstrapNode(node);
					}))
			.Merge(maxConcurrent : 2)
			.ObserveOnDispatcher()
			.Subscribe(u => { }, () =>
			{
				// Back on UI thread - Code completed
			});
