    async Task TopLevelAsync()
    {
        var syncContext = SynchronizationContext.Current;
        SynchronizationContext.SetSynchronizationContext(null);
        try
        {
            // no need for ConfigureAwait(false)
            await SubTask1Async();
            await SubTask2Async();
        }
        finally
        {
             SynchronizationContext.SetSynchronizationContext(syncContext);
        }
    }
