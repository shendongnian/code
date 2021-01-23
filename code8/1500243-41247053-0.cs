    private static async Task SomeCPUBoundTask()
        {
            // Insert actual CPU-bound task here using Task.Run
            await Task.Delay(100);
        }
        public static async Task QueueCPUBoundTasks()
        {
            List<Task> tasks = new List<Task>();
            // Queue up however many CPU-bound tasks you want
            for (int i = 0; i < 10; i++)
            {
                // We could just call Task.Run(...) directly here
                Task task = SomeCPUBoundTask();
                tasks.Add(task);
            }
            // Wait for all of them to complete
            // Note that I don't have to write any explicit locking logic here,
            // I just tell the framework to wait for all of them to complete
            await Task.WhenAll(tasks);
        }
