    public class MyAsyncQueueRequireingInitialization
    {
        private readonly Lazy<Task> whenInitialized;
        public MyAsyncQueueRequireingInitialization()
        {
            whenInitialized = new Lazy<Task>(OneTimeInitAsync);
        }
        //as noted in comments, the taskID isn't actually needed for initialization
        private async Task OneTimeInitAsync() 
        {
            Console.WriteLine($"Performing initialization");
            /* Do some lengthy initialization */
            await Task.Delay(TimeSpan.FromSeconds(3));
            Console.WriteLine($"Completed initialization");
        }
        public async Task ProcessJobAsync(int taskID, int jobId)
        {
            await whenInitialized.Value;
            /* Do something lengthy with the jobId */
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine($"Completed job {jobId}.");
        }
    }
