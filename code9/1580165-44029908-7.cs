    private async void RunScanTcp(object stateInfo)
    {
        // Do CPU bound operation here.
        var a = 100;
        while (--a != 0)
        {
            // using TaskCompletionSource
            var tcs = new TaskCompletionSource<bool>();
        
            RunOnUiThread(() =>
            {
                // Update UI here.
    
                // Set result
                tcs.TrySetResult(true);
            });
        
            // Wait until UI operationds.
            tcs.Task.Wait();
        }
    }
