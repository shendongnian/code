    public static async Task OnCompletedSuccessfully(this Task task, Action continuation,
        bool continueOnCapturedContext = true)
    {
        await task.ConfigureAwait(continueOnCapturedContext);
        continuation();
    }
    public static async Task OnCompletedSuccessfully(this Task task, Func<Task> continuation,
        bool continueOnCapturedContext = true)
    {
        await task.ConfigureAwait(continueOnCapturedContext);
        await continuation().ConfigureAwait(false);
    }
    public static async Task OnCompletedSuccessfully<TResult>(
        this Task<TResult> task, Action<TResult> continuation,
        bool continueOnCapturedContext = true)
    {
        var result = await task.ConfigureAwait(continueOnCapturedContext);
        continuation(result);
    }
    public static async Task OnCompletedSuccessfully<TResult>(
        this Task<TResult> task, Func<TResult, Task> continuation,
        bool continueOnCapturedContext = true)
    {
        var result = await task.ConfigureAwait(continueOnCapturedContext);
        await continuation(result).ConfigureAwait(false);
    }
    public static async Task<TNewResult> OnCompletedSuccessfully<TResult, TNewResult>(
        this Task<TResult> task, Func<TResult, TNewResult> continuation,
        bool continueOnCapturedContext = true)
    {
        var result = await task.ConfigureAwait(continueOnCapturedContext);
        return continuation(result);
    }
    public static async Task<TNewResult> OnCompletedSuccessfully<TResult, TNewResult>(
        this Task<TResult> task, Func<TResult, Task<TNewResult>> continuation,
        bool continueOnCapturedContext = true)
    {
        var result = await task.ConfigureAwait(continueOnCapturedContext);
        return await continuation(result).ConfigureAwait(false);
    }
