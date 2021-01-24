    // Random async method here ...
    private async Task<int> DelayAsync(int seconds)
    {
        await Task.Delay(seconds*1000)
            .ConfigureAwait(false);
        Trace.WriteLine($"Done waiting {seconds} seconds");
        return seconds;
    }
    [HttpGet]
    public IHttpActionResult ParallelAsync()
    {
        // Create some tasks 
        var tasks = Enumerable.Range(1, 5)
            .Select(DelayAsync)
            .ToArray();
    #pragma warning disable 4014
        // Not awaited
        Task.WhenAll(tasks)
            // Since we aren't awaiting, we'll need to revert to old school continuations, if we need to do work after all tasks DO complete
            .ContinueWith(
            t =>
            {
                // NB : Check for, and observe any exceptions prior to accessing result
                if (t.IsFaulted)
                {
                    // Exception handler here
                }
                Trace.WriteLine($"Done waiting for a total of {t.Result.Sum()} seconds");
            });
    #pragma warning restore 4014
        // Return immediately after initiating the async tasks
        return Ok();
    }
