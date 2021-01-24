    #pragma warning disable 4014
    var backgroundTasks = Enumerable.Range(1, 5)
        .Select(DelayAsync);
    // Not awaited
    Task.WhenAll(backgroundTasks)
        .ContinueWith(t =>
        {
            if (t.IsFaulted)
            {
                // Exception handler here
            }
            Trace.WriteLine($"Done waiting for a total of {t.Result.Sum()} seconds");
        });
    #pragma warning restore 4014
