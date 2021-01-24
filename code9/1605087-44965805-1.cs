    private async Task LengthyProcessing(...)
    {
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        tokenSource.CancelAfter(TimeSpan.FromSeconds(5));
        CancellationToken myCancellationToken = tokenSource.Token
        try
        {
           // Start one task, don't await yet:
           var myTask = await MyProcessAsync(myCancellationToken, ...)
           // during processing there will be regular check if cancellation requested
           // meanwhile, whenever myTask has to await, I can do some processing
           // I'll have to check for cancellation regularly also:
           while(...)
           {
               myCancellationToken.ThrowIfCancellationRequested();
               DoSomeProcessing();
               ...
           }
           
           MyResult result = await myTask;
           // if here, not cancelled. can use Result:
           ProcessResult(result);
        }
        catch (OperationCanceledException exc)
        {
            ProcessOperationCanceled();
        }
    }
