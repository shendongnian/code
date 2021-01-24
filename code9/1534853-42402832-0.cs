    bool sendPos = true;
    
    public async Task SomeFunction(CancellationToken token)
    {
        while (sendPos)
        {
            SendServoPos();
            await Task.Delay(1000, token)
        }
    }
    
    public void MainFunction()
    {
        var tokenSource = new CancellationTokenSource();
        // Fire and Forget - Note it will silently throw exceptions
        SomeFunction(tokenSource.Token)
        
        // Cancel Loop
        sendPos = false;
        tokenSource.Cancel();
    }
