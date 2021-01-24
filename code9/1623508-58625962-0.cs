    public static async Task<TResult[]> WhenAll<TResult>(
        this IEnumerable<ValueTask<TResult>> tasks)
    {
        var byCompletionStatus = tasks
            .Select((t, i) => (ValueTask: t, Index: i))
            .ToLookup(p => p.ValueTask.IsCompleted);
        var completedResults = byCompletionStatus[true]
            .Select(p => (p.ValueTask.Result, p.Index));
        var pendingTasks = byCompletionStatus[false]
            .Select(p => (Task: p.ValueTask.AsTask(), p.Index));
        await Task.WhenAll(pendingTasks.Select(p => p.Task)).ConfigureAwait(false);
        var pendingResults = pendingTasks
            .Select(p => (p.Task.Result, p.Index));
        return completedResults.Concat(pendingResults)
            .OrderBy(p => p.Index)
            .Select(p => p.Result)
            .ToArray();
    }
