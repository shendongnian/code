    [AsyncTimeout(duration:10000)] //The timeout value in milliseconds.
    [HandleError(ExceptionType = typeof(TimeoutException),
                                View = "TimeoutError")]
    public async Task<ActionResult> LongTask(CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(20), cancellationToken);
        return Content("Done");
    }
