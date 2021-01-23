    public static class TaskExtensions
    {
        public static Task IgnoreCancellation(this Task task)
        {
            return task.ContinueWith(t => { }, TaskContinuationOptions.OnlyOnCanceled);
        }
    }
