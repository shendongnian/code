    public async Task RunTimer(Action act,TimeSpan delay,CancellationToken token)
    {
        while(!token.IsCancellationRequested)
        {
            await Task.Delay(delay,token);
            if (!token.IsCancellationRequested)
            {
                act();
            }
        }   
    }
