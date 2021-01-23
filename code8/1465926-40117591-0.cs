    public async Task DoProcess()
    {
        try
        {
            await Start();
        }
        catch (Exception e)
        {
        }
    }
    
    public Task DoProcess()
    {
        try
        {
            Start().Wait();
        }
        catch (Exception e)
        {
        }
    } 
