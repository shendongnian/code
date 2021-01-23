    public static IEnumerable<Task<Task>> Order2(this IEnumerable<Task> tasks)
    {
        var taskList = tasks.ToList();
        var taskSources = new BlockingCollection<TaskCompletionSource<Task>>();
        var taskSourceList = new List<TaskCompletionSource<Task>>(taskList.Count);
        foreach (var task in taskList)
        {
            var newSource = new TaskCompletionSource<Task>();
            taskSources.Add(newSource);
            taskSourceList.Add(newSource);
            task.ContinueWith(t => taskSources.Take().TrySetResult(t),
                CancellationToken.None, TaskContinuationOptions.PreferFairness, TaskScheduler.Default);
        }
        return taskSourceList.Select(tcs => tcs.Task);
    }
