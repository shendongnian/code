    public static class TaskExtension
    {
        public async static Task<T> Cast<T>(this Task task)
        { 
            if (!task.GetType().IsGenericType) throw new InvalidOperationException();
            await task.ConfigureAwait(false);
            // Harvest the result. Ugly but works
            return (T)((dynamic)task).Result;
        }
    }
