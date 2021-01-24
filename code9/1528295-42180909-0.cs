    static void Main(string[] args)
    {
        Task createdTask = RunTestTaskAsync();
        
        createdTask.ConfigureAwait(false);
        createdTask.ContinueWith(
            task => Console.WriteLine("Task State In Continue with => {0}", task.Status)).Wait();
    }
    private static async Task RunTestTaskAsync()
    {
        throw new Exception("CrashingRoutine: Crashing by Design");
    }
