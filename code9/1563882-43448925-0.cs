    public class Program
    {
        private static void Main(string[] args)
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            var sched = schedFact.GetScheduler();
            sched.Start();
            // define the job and tie it to our HelloJob class
            var job = JobBuilder.Create<HelloJob>()
                .WithIdentity("myJob", "group1")
                .Build();
            // Trigger the job to run now, and then every 40 seconds
            var trigger = TriggerBuilder.Create()
                .WithIdentity("trigger3", "group1")
                .WithCronSchedule("0/10 * * * * ?", cs => cs.WithMisfireHandlingInstructionDoNothing())
                .ForJob("myJob", "group1")
                .Build();
            sched.ScheduleJob(job, trigger);
            Console.WriteLine("Ctrl+C to exit.");
            Console.ReadKey();
        }
    }
    [DisallowConcurrentExecution]
    public class HelloJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("HelloJob is executing." + DateTime.Now);
            Thread.Sleep(TimeSpan.FromSeconds(30));
        }
    }
