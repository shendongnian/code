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
        // Initiate unawaited background tasks ...
        #pragma warning disable 4014
        DelayAsync(100);
        #pragma warning enable 4014
        // Return first result to client without waiting for the background task to complete
        return Ok(firstResult);
    }
