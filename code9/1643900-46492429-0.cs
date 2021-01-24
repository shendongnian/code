    protected override void OnStart(string[] args)
    {
        _thread.Factory.Run(StartAsync).ContinueWith(t =>
        {
            var aggregate = t.Exception.Flatten();
            foreach(var exception in aggregate.InnerExceptions)
            {
                // Handle exception
            }
        }, TaskContinuationOptions.OnlyOnFaulted);
    }
