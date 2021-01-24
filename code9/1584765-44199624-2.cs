    public async Task<string> DoAsync(CancellationToken token) {
      var result = await Task.Run(() =>  {
        //TODO: you may want to pass token to DoHeavyRequest() and cancel there as well
        token.ThrowIfCancellationRequested();
        DoHeavyRequest(); // 1
        token.ThrowIfCancellationRequested();
        DoHeavyRequest(); // 2
        token.ThrowIfCancellationRequested();
        DoHeavyRequest(); // 3
        token.ThrowIfCancellationRequested();
        DoHeavyRequest(); // 4
        return "success";
      });
      return "results";
    }
    // Let's preserve the current interface - call without cancellation
    public async Task<string> DoAsync() {
      return await DoAsync(CancellationToken.None);
    }
...
    // Run, wait up to 7 seconds then cancel 
    try {
      using (CancellationTokenSource cts = new CancellationTokenSource(7000)) {
        // Task completed, its result is in the result
        string result = await DoAsync(cts.Token);
        
        //TODO: Put relevant code here 
      }  
    catch (TaskCanceledException) { 
      // Task has been cancelled (in this case by timeout)
      
      //TODO: Put relevant code here  
    }
