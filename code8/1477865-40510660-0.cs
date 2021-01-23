	void Main()
	{
		Task.Run(() => Worker()).Wait();
		Console.WriteLine("DONE");
	}
	
	async Task Worker()
	{
		if (SynchronizationContext.Current != null)
			throw new InvalidOperationException("Don't want any synchronization!");
	
		var cancellation = new CancellationTokenSource(55000).Token; // gets cancelled after 5.5s
		cancellation.Register(() => Console.WriteLine("token is cancelled now"));
	
		var flow = new ActionBlock<TimeSpan>(
			async ts =>
			{
				Console.WriteLine("[START] Elapsed: {0}; cancelled: {1}", ts, cancellation.IsCancellationRequested);
				await Task.Delay(2500).ConfigureAwait(false); // processing takes more time than items need to produce
				Console.WriteLine("[STOP] Elapsed: {0}; cancelled: {1}", ts, cancellation.IsCancellationRequested);
			},
			new ExecutionDataflowBlockOptions
			{
				BoundedCapacity = 2, // Buffer 1 item ahead
				EnsureOrdered = true,
				CancellationToken = cancellation,
			});
	
		Func<TimeSpan, Task<bool>> observer = ts => flow.SendAsync(ts, cancellation);
	
		BaseClass provider = new Implementation();
		await provider.CreateValues(observer, cancellation).ConfigureAwait(false);
		Console.WriteLine("provider.CreateValues done");
	
		flow.Complete();
		await flow.Completion.ConfigureAwait(false);
		Console.WriteLine("flow completed");
	}
	
	abstract class BaseClass
	{
		// allow implementers to use async-await
		public abstract Task CreateValues(Func<TimeSpan, Task<bool>> observer, CancellationToken cancellation);
	}
	
	class Implementation : BaseClass
	{
		public override async Task CreateValues(Func<TimeSpan, Task<bool>> observer, CancellationToken cancellation)
		{
			try
			{
				var sw = Stopwatch.StartNew();
				for (int i = 0; i < 10; i++)
				{
					for (int j = 0; j < 3; j++)
					{
						Console.WriteLine("{0}/{1} cancelled:{2}", i, j, cancellation.IsCancellationRequested);
						Thread.Sleep(333);
					}
	
					if (cancellation.IsCancellationRequested)
						throw new ApplicationException("token is cancelled");
	
					var value = sw.Elapsed;
					var queued = await observer(value); // use of "observer" encorces async-await even if there is nothing else async
					Console.WriteLine("[{0}] '{1}' @ {2}", queued ? "enqueued" : "skipped", value, sw.Elapsed);
	
					if (!queued)
						; // Dispose item
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw;
			}
		}
	}
