    public static Task When(this TaskFactory taskFactory, Task task, Action<Task> continuationAction)
    {
        return task.ContinueWith(continuationAction, taskFactory.CancellationToken, taskFactory.ContinuationOptions, taskFactory.Scheduler);
    }
    
    public static Task<TResult> When<TResult>(this TaskFactory taskFactory, Task task, Func<Task, TResult> continuationFunction)
    {
        return task.ContinueWith(continuationFunction, taskFactory.CancellationToken, taskFactory.ContinuationOptions, taskFactory.Scheduler);
    }
    // Repeat with argument combinations:
    // - Task<TResult> task (instead of non-generic Task task)
    // - object state
    // - bool notOnRanToCompletion (useful in C# before 6)
