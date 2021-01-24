    public static async Task CancelOnError(this Task task, CancellationTokenSource cts)
    {
        try
        {
            await task.ConfigureAwait(false);
        }
        catch
        {
            cts.Cancel();
            throw;
        }
    }
    public static async Task<TTaskResult> CancelOnError<TTaskResult>(this Task<TTaskResult> task, CancellationTokenSource cts)
    {
        await ((Task)task).CancelOnError(cts);
        return task.Result;
    }
