	void Main()
	{
		var sequence = CreateSubscriptions( new[] {1,5,6});
		sequence.Subscribe((i) => {}, () => { Console.WriteLine("all ready"); });
		
		//sequence.Wait();
		//Console.WriteLine("all ready");
	}
	private IList<IDisposable> subscriptions = new List<IDisposable>();
	private IObservable<int> CreateSubscriptions(IEnumerable<int> integers)
	{
		if (this.subscriptions.Any())
			foreach (IDisposable subscription in this.subscriptions)
				subscription.Dispose();
		this.subscriptions.Clear();
		var sequences = new List<IObservable<int>>();
		
		for (int ix = 0; ix < 5; ix++)
		{    
			var sequence = Observable.Create<int>(
					observer =>
					{
						foreach (int i in integers)
							observer.OnNext(i);
						observer.OnCompleted();
						return System.Reactive.Disposables.Disposable.Empty;
					}
				);
			sequences.Add(sequence);	
			this.subscriptions.Add(sequence.Subscribe(nr => 
			{  
				Console.WriteLine(nr); 
			}));
		}
		
		return Observable.Merge(sequences);
	}
