    public class JobScheduler
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            IJobDetail emailJob = JobBuilder.Create<EmailJob>().StoreDurably().WithIdentity("massEmail", "emailGroup").Build();
            ITrigger trigger = TriggerBuilder.Create()
                                .WithIdentity("massEmailTrigger", "emailGroup")
                                .WithSimpleSchedule(x => x
                                    .WithIntervalInMinutes(1)
                                    .RepeatForever())
                                .Build();
            scheduler.ScheduleJob(emailJob, trigger);
        }
    }
