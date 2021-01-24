    public async Task DoSomeProcessing()
    {
        IsWorking = true;
        await Task.Run(() =>
        {
           // do some long processing
        });
        IsWorking = false;
    }
