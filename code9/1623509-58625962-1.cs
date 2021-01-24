    public static async Task<TResult[]> WhenAll<TResult>(
        this IEnumerable<ValueTask<TResult>> tasks)
    {
        // The volatile property IsCompleted must be accessed only once
        var tasksArray = tasks.Select(t => t.IsCompleted ?
            (
                HasResult : true,
                Result: t.Result,
                Task: (Task<TResult>)null
            ) : (
                HasResult : false,
                Result: default(TResult),
                Task: t.AsTask()
            ))
            .ToArray();
        var pendingTasks = tasksArray
            .Where(t => !t.HasResult)
            .Select(t => t.Task);
        await Task.WhenAll(pendingTasks).ConfigureAwait(false);
        return tasksArray
            .Select(t => t.HasResult ? t.Result : t.Task.Result)
            .ToArray();
    }
