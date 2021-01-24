    // Random async method here ...
    private async Task<int> DelayAsync(int seconds)
    {
        await Task.Delay(seconds*1000)
            .ConfigureAwait(false);
        Trace.WriteLine($"Done waiting {seconds} seconds");
        return seconds;
    }
    [HttpGet]
    public async Task<IHttpActionResult> ParallelBackgroundTasks()
    {
        var firstResult = await DelayAsync(6)
            .ConfigureAwait(false);
        
        // Initiate unawaited background tasks
        var backgroundTasks = Enumerable.Range(1, 5)
            .Select(DelayAsync)
            // `Materialize` is needed in order to initiate tasks
            .ToArray();
        return Ok(firstResult);
    }
