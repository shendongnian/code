    public static class Extensions
    {
        public static async Task ContinueWithInfinitly(this Task task, Func<Task> continuationAction, CancellationToken cancellationToken)
        {
            await task;
            if (!cancellationToken.IsCancellationRequested)
            {
                var newTask = continuationAction.Invoke();
                await task.ContinueWithInfinitly(continuationAction, cancellationToken);
            }
        }
    }
