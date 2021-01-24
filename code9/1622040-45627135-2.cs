    // Random async method here ...
    private async Task<int> DelayAsync(int seconds)
    {
        await Task.Delay(seconds*1000)
            .ConfigureAwait(false);
        Trace.WriteLine($"Done waiting {seconds} seconds");
        return seconds;
    }
    [HttpGet]
    public async Task<IHttpActionResult> ParallelAsync()
    {
        var firstResult = await DelayAsync(123)
            .ConfigureAwait(false);
        
        // Unawaited tasks
        var tasks = Enumerable.Range(1, 5)
            .Select(DelayAsync)
            .ToArray();
    // Kick off the other tasks, but don't wait around for the response
    #pragma warning disable 4014
        Task.WhenAll(tasks)
            // Even if the original request thread has completed, it is still possible to 
            // schedule a continuation upon completion
            .ContinueWith(
            t =>
            {
                if (t.IsFaulted)
                {
                    // Exception handler here
                }
                Trace.WriteLine($"Done waiting for a total of {t.Result.Sum()} seconds");
            });
    #pragma warning restore 4014
        return Ok(firstResult);
    }
