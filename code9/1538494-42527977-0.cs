    public static Task<WhenAllWithTokenResult<TToken>> WhenAllWithToken<TToken>(Tuple<Task, TToken>[] tasks)
    {
        var successfulTasks = new List<Tuple<Task, TToken>>();
        var failedTasks = new List<Tuple<Task, TToken>>();
        var cancelledTasks = new List<Tuple<Task, TToken>>();
        int amountCompleted = 0;
        var taskCompletionSource = new TaskCompletionSource<WhenAllWithTokenResult<TToken>>();
        // Register ContinueWith callback for each task and add it to the according result list when completed
        foreach (var tuple in tasks)
        {
            var copyOfTuple = tuple;
            tuple.Item1.ContinueWith(_ =>
            {               
                if (_.IsFaulted)
                {
                    failedTasks.Add(copyOfTuple);
                }
                else if (_.IsCanceled)
                {
                    cancelledTasks.Add(copyOfTuple);
                }
                else if (_.IsCompleted)
                {
                    successfulTasks.Add(copyOfTuple);
                }
                if (Interlocked.Increment(ref amountCompleted) == tasks.Length)
                {
                    // All tasks finished so let's set the result of this method
                    taskCompletionSource.SetResult(new WhenAllWithTokenResult<TToken>(successfulTasks, failedTasks, cancelledTasks));
                }
            });
        }
        return taskCompletionSource.Task;
    }
    public class WhenAllWithTokenResult<TToken>
    {
        public IList<Tuple<Task, TToken>> SuccessfulTasks { get; private set; }
        public IList<Tuple<Task, TToken>> FailedTasks { get; private set; }
        public IList<Tuple<Task, TToken>> CancelledTasks { get; private set; }
        public WhenAllWithTokenResult(IList<Tuple<Task, TToken>> successfulTasks, IList<Tuple<Task, TToken>> failedTasks, IList<Tuple<Task, TToken>> cancelledTasks)
        {
            CancelledTasks = cancelledTasks;
            SuccessfulTasks = successfulTasks;
            FailedTasks = failedTasks;
        }
    }
