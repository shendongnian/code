    public static async Task<TResult> LogAsyncTask<TResult>(
        Func<Task<TResult>> asyncMethod, string messageTemplate,
        LogEventLevel level = LogEventLevel.Information)
    {
        Log.Write(level, "Async Starting: " + messageTemplate);
        try
        {
            return await asyncMethod().ConfigureAwait(false);
        }
        finally
        {
            Log.Write(level, "Async Finished: " + messageTemplate);
        }
    }
    public static async Task LogAsyncTask(
        Func<Task> asyncMethod, string messageTemplate,
        LogEventLevel level = LogEventLevel.Information)
    {
        Log.Write(level, "Async Starting: " + messageTemplate);
        try
        {
            await asyncMethod().ConfigureAwait(false);
        }
        finally
        {
            Log.Write(level, "Async Finished: " + messageTemplate);
        }
    }
