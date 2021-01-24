    // prototype code
    static class TaskThrottlingExtension
    {
        public static async Task ThrottleProcessingAsync<T>(this IEnumerable<T> inputs, int parallel, Func<T, Task> process)
        {
            var queues = new BlockingCollection<T>[parallel];
            var tasks = new Task[parallel];
            for (int i = 0; i < parallel; i++)
            {
                var queue = queues[i] = new BlockingCollection<T>(1);
                tasks[i] = Task.Run( async () =>
                {
                    foreach (var input in queue.GetConsumingEnumerable())
                    {
                        await process(input).ConfigureAwait(false);
                    }
                });
            }
            try
            {
                foreach (var input in inputs)
                {
                    BlockingCollection<T>.AddToAny(queues, input);
                }
                foreach (var queue in queues)
                {
                    queue.CompleteAdding();
                }
                await Task.WhenAll(tasks).ConfigureAwait(false);
            }
            finally
            {
                foreach (var queue in queues)
                {
                    queue.Dispose();
                }
            }
        }
    }
