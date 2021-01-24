    var reset = new ManualResetEvent(false);
    
    var cts = new CancellationTokenSource();
    cts.Token.Register(() => Console.WriteLine("Token cancelled."));
    
    var observable = Observable
    	.Interval(TimeSpan.FromMilliseconds(250))
    	.TakeWhile(x => !cts.Token.IsCancellationRequested)
    	.Finally(
    		() =>
    			{
    				Console.WriteLine("Finally: Beginning finalization.");
    				Thread.Sleep(500);
    				Console.WriteLine("Finally: Done with finalization.");
    				reset.Set();
    			});
    
    await Task.Factory.StartNew(
    	() => observable
    		.Subscribe(
    			value =>
    				{
    					Console.WriteLine("Begin: {0}", value);
    					Thread.Sleep(2000);
    					Console.WriteLine("End: {0}", value);
    				},
    			() => Console.WriteLine("Completed: Subscription completed.")),
    	TaskCreationOptions.LongRunning);
    
    Console.ReadLine();
    cts.Cancel();
    reset.WaitOne();
    Console.WriteLine("Job terminated.");
