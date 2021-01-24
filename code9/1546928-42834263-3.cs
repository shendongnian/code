    public static Task<Task[]> WhenAllOrFirstException(params Task[] tasks)
    {
        var countdownEvent = new CountdownEvent(tasks.Length);
        var completer = new TaskCompletionSource<Task[]>();
        Action<Task> onCompletion = completed =>
            {
                if (completed.IsFaulted && completed.Exception != null)
                {
                    completer.TrySetException(completed.Exception.InnerExceptions);
                }
                if(countdownEvent.Signal() && !completer.Task.IsCompleted)
                {
                    completer.TrySetResult(tasks);
                }
            };
        foreach(var task in tasks)
        {
            task.ContinueWith(onCompletion)
        }
        return completer.Task;
    }
