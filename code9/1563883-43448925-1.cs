    [DisallowConcurrentExecution]
    public class HelloJob : IJob
    {
        public static int count = 1;
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("HelloJob strted On." + DateTime.UtcNow.Ticks);
            if (count == 1)
                Thread.Sleep(TimeSpan.FromSeconds(30));
    
            Interlocked.Increment(ref count);
        }
    }
