	void Main()
	{
		int number_of_streams = 10;
		
		IObservable<int> query =
			Observable
				.Range(0, number_of_streams)
				.Select(stream_number =>
					Observable
						.Defer(() => Observable.Start(() => nextJob(stream_number)))
						.Repeat())
				.Merge();
	
		IDisposable subscription =
			query
				.Subscribe(x => Console.WriteLine(x));
	}
	
	public int nextJob(int streamNumber)
	{
		Thread.Sleep(10000);
		return streamNumber;
	}
