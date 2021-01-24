    private static async Task ExecuteMethodAsync(IProgress<double> progress = null)
    {
        double percentComplete = 0;
        bool done = false;
        await Task.Delay(1);
        while (!done)
        {
            if (progress != null)
            {
                progress.Report(percentComplete);
            }
            percentComplete += 10;
            if(percentComplete == 100)
            {
                done = true;
            }
        }
    }
