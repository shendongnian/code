    protected override async void OnStart(string[] args)
    {
        try
        {     
            await _thread.Factory.Run(StartAsync);
        }
        catch (Exception ex)
        {                
            // Exception!
        }
    }
