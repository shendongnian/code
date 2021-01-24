    using System;
    using FluentScheduler;
    
    namespace SchedulerDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Start the scheduler
                JobManager.Initialize(new ScheduledJobRegistry());
    
                // Wait for something
                Console.WriteLine("Press enter to terminate...");
                Console.ReadLine();
    
                // Stop the scheduler
                JobManager.StopAndBlock();
            }
        }
    
        public class ScheduledJobRegistry : Registry
        {
            public ScheduledJobRegistry()
            {
                Schedule<MyJob>()
                        .NonReentrant() // Only one instance of the job can run at a time
                        .ToRunOnceAt(DateTime.Now.AddSeconds(3))    // Delay startup for a while
                        .AndEvery(2).Seconds();     // Interval
    
                // TODO... Add more schedules here
            }
        }
    
        public class MyJob : IJob
        {
            public void Execute()
            {
                // Execute your scheduled task here
                Console.WriteLine("The time is {0:HH:mm:ss}", DateTime.Now);
            }
        }
    }
