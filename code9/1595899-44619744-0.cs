    public static class TaskCancellations
    {
        public static async Task<T> WithCancellation<T>(
            this Task<T> task,
            CancellationToken token)
        {
            var cancellation = new TaskCompletionSource<bool>();
            using (token.Register(s =>
                 (s as TaskCompletionSource<bool>).TrySetResult(true), cancellation))
            {
                if (task != await Task.WhenAny(task, cancellation.Task))
                    throw new OperationCanceledException(token);
                return await task;
            }
        }
    }
