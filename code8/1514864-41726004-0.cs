    using Quartz;
    using System;
    
    namespace MyApp
    {
        public static class SchedulerExtensions
        {
            public static DateTimeOffset ScheduleJob(this IScheduler scheduler, Action action, TimeSpan initialDelay, TimeSpan interval)
            {
                var data = new JobDataMap();
                data.Add("_", action);
    
                var jobDetail = JobBuilder.Create<GenericJob>().UsingJobData(data).Build();
    
                var trigger = TriggerBuilder.Create()
                    .StartAt(DateTimeOffset.UtcNow.Add(initialDelay))
                    .WithSimpleSchedule(s => s.WithInterval(interval).RepeatForever())
                    .Build();
    
                return scheduler.ScheduleJob(jobDetail, trigger);
            }
    
            class GenericJob : IJob
            {
                public void Execute(IJobExecutionContext context)
                {
                    (context.JobDetail.JobDataMap["_"] as Action)?.Invoke();
                }
            }
        }
    }
