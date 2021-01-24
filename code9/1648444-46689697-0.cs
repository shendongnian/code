    private int check = 1;
    
    private async Task AsyncMethod(CancellationToken token)
    {
        check = 2;
        await Task.Delay(5000, token); //Wait for 5 seconds or till the token is signaled.
        token.ThrowIfCancellationRequested();
        check = 3;
    }
    
    //Event handlers like this is the only place you are allowed to do async void
    private async void Load(object sender, EventArgs e)
    {
        Debug.WriteLine("1: " + check);
        try
        {
            var cts = new CancellationTokenSource();
            var task = AsyncMethod(cts.Token); //Start the task
            cts.Cancel();
            await task; //Wait for the task to finish or throw a OperationCanceledException
            Debug.WriteLine("2: " + check);
        }
        catch(OperationCanceledException)
        {
            //Do nothing
        }
        Debug.WriteLine("3: " + check);
    }
