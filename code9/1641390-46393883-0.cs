	void Main()
	{
		var c = new Processor();
		c.SetupBufferedProcessor(2, TimeSpan.FromMilliseconds(1000));
		
		c.Enqueue("A");
		c.Enqueue("B");
		c.Enqueue("C");
			
		Console.ReadLine();	
		
		// When application has ended, flush the buffer
		c.Dispose(); 
	}
	
	
	public sealed class Processor : IDisposable
	{
		private IDisposable subscription;
		private Subject<string> subject = new Subject<string>();
	
		public void Enqueue(string item)
		{
			subject.OnNext(item);		
		}
		
		public void SetupBufferedProcessor(int bufferSize, TimeSpan bufferCloseTimespan)
		{
			// Create a subscription that will produce a set of strings every second 
            // or when buffer has 2 items, whatever comes first
			subscription = subject.AsObservable()
				.Buffer(bufferCloseTimespan, bufferSize)
				.Where(list => list.Any()) // suppress empty list (no items enqueued for 1 second)
				.Subscribe(async list =>
				{
					await Task.Run(() =>
					{
						Console.WriteLine(string.Join(",", list)); 
						Thread.Sleep(2000);
					});
				});
		}
		
		public void Dispose()
		{
			subscription?.Dispose();
		}
	}
