    void Main()
    {
	    var tokenSource = new CancellationTokenSource();
    	System.Threading.Tasks.Task.Run(() => BackgroundThread(tokenSource.Token));
	
    	Thread.Sleep(5000);
    	tokenSource.Cancel();	
    }
    private void BackgroundThread(CancellationToken token)
    {
    	while (token.IsCancellationRequested == false) {
    		Console.Write(".");
    		Thread.Sleep(1000);
    	}
    	
    	Console.WriteLine("\nCancellation Requested Thread Exiting...");
    }
