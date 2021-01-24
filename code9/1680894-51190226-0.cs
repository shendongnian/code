    public static class TaskExtension
    {
        public async static Task<T> Cast<T>(this Task task)
        {
            await task.ConfigureAwait(false);
            // Harvest the result. Ugly but works
            return (T)((dynamic)task).Result;
        }
    }
