    private bool CanStoreCommand()
    {
        return canRun;
    }
    // note the async here
    private async void StoreActionCommand()
    {
        CanRun = false;
        
        // notification
        var progressNotification = new Progress<string>((value) => ExecutionStatus = value);
        // real background thread goes here, without blocking the UI
        await Task.Run(() => {
            DoWork(progressNotification);
        });
        CanRun = True;
    }
    private void DoWork(IProgress<string> progress)
    {
        progress.Report("Starting...");
        try
        {
            progress.Report("doing x...");
            progress.Report("doing y...");
        }
        catch(Exception err)
        {
            progress.Report(err);
        }
        progress.Report("Process finished");
    }
