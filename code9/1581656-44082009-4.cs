    public static async Task Loop(CancellationTokenSource cts)
    {
        while (cts != null && !cts.IsCancellationRequested)
        {
            // your work you want to keep iterating until cancelled
        }
    }
