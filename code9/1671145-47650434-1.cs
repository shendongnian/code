    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
     
    using Common.Logging;
     
    using Quartz;
    using Quartz.Impl;
     
    namespace FooBar
    {
        class Program
        {
     
            private static ILog Log = LogManager.GetCurrentClassLogger();
     
            static void Main(string[] args)
            {
                try
                {
                    // construct a scheduler factory
                    ISchedulerFactory schedFact = new StdSchedulerFactory();
     
                    // get a scheduler
                    IScheduler sched = schedFact.GetScheduler();
                    sched.Start();
     
                    IJobDetail job = JobBuilder.Create<LoggingJob>()
                        .WithIdentity("myJob", "group1")
                        .Build();
     
                    ITrigger trigger = TriggerBuilder.Create()
                        .WithDailyTimeIntervalSchedule
                        (s =>
                            s.WithIntervalInSeconds(10)
                                .OnEveryDay()
                                .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(10, 15))
                        )
                        .Build();
     
                    sched.ScheduleJob(job, trigger);
                }
                catch (ArgumentException e)
                {
                    Log.Error(e);
                } 
            }
        }
    }
    
    
