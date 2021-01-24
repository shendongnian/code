    /// <summary>
    /// Executes a task every x milliseconds, but will wait for long running tasks to complete.
    /// </summary>
    /// <param name="execute">A Task Producer</param>
    /// <param name="milliseconds">How often to run execute</param>
    /// <param name="cancel">A cancellation token</param>
    /// <returns></returns>
    private async Task ExecuteEvery(Func<Task> execute, int milliseconds, CancellationToken cancel)
    {
        while (true)
        {
            var delay = Task.Delay(milliseconds, cancel);
            await Task.WhenAll(delay, execute());
            if(cancel.IsCancellationRequested) break;
        }
    }
