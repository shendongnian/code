       public sealed class OrderJobSchedule
        {
            public void Start()
            {
                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
                scheduler.Start();
    
                IJobDetail job = JobBuilder.Create<OrderJob>().Build();
    
                ITrigger trigger = TriggerBuilder.Create()
                       .WithSimpleSchedule(a => a.WithIntervalInSeconds(15).RepeatForever())
                       .Build();
    
                scheduler.ScheduleJob(job, trigger);
            }
    
            public void Stop()
            {
                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
                scheduler.Shutdown();
            }
        }
