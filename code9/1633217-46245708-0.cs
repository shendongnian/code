    public static async Task<TResult> LogAsyncTask<TResult>(
        this Task<TResult> task, string messageTemplate,
        LogEventLevel level = LogEventLevel.Information)
    {
      Log.Write(level, "Async Starting: " + messageTemplate);
      try
      {
        return await task.ConfigureAwait(false);
      }
      finally
      {
        Log.Write(level, "Async Finished: " + messageTemplate);
      }
    }
    public static Task LogAsyncTask(
        this Task task, string messageTemplate, 
        LogEventLevel level = LogEventLevel.Information)
    {
      return LogAsyncTask<object>(async () =>
      {
        await task.ConfigureAwait(false);
        return null;
      }, messageTemplate, level);
    }
