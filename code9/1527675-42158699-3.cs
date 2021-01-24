    async Task Main()
    {
	    var cts = new CancellationTokenSource();
    	var ct = cts.Token;
    	cts.CancelAfter(500);
	
    	Task t = null;
    	try
    	{
    		t = Task.Run(() => { Thread.Sleep(1000); ct.ThrowIfCancellationRequested(); }, ct);
    		await t;
    		Console.WriteLine(t.IsCanceled);
    	}
    	catch (OperationCanceledException)
    	{
    		Console.WriteLine(t.IsCanceled);
    	}
    }
