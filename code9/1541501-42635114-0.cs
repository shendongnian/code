    public async void AsyncTest()
    {
        await SendReport();
    
        Debug.WriteLine("created");
    
    }
    
    private async Task SendReport()
    {
        await MyHeavyCodeIO(); //IO bound
        await Task.Run(() => MyHeavyCodeCPU()); //CPU bound
        Debug.WriteLine("Code Finished");
    }
    private async MyHeavyCodeIO()
    {
        //Heavy work...
        await Task.Delay(5000);
    }
    private async MyHeavyCodeCPU()
    {
        //Heavy work...
        await Task.Delay(5000);
    }
