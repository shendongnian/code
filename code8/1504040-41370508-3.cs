    async Task SomeAsyncRoutine()
    {
        var progress = new Progress<double>();
        progress.ProgressChanged += (sender, args) => 
        {
            // Update your progress bar and do whatever else you need
        };
        
        await SomeAsynMethod(progress);
    }
