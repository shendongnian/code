    var cts = new CancellationTokenSource();
    
    var newTask = Task.Factory.StartNew(state =>
    {
    	var token = (CancellationToken)state;
    	if (!token.IsCancellationRequested)
    	{
    		var invokeInput = new object[] { input };
    		var output = mi.Invoke(o, invokeInput);
    	}
    }, cts.Token, cts.Token);
    
    
    if (!newTask.Wait(timeout, cts.Token))
    {
    	cts.Cancel();
    	throw new Exception("The operation has timed out.");
    }
