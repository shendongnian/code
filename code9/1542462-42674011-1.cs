    public class TaskScheduler : ITaskScheduler
    {
        #region Private fields
        private readonly IScheduler _scheduler;
        #endregion
        #region Constructors
        public TaskScheduler(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }
        #endregion
        #region ITaskScheduler members
        public string Name
        {
            get { return this.GetType().Name; }
        }
        public void Run()
        {
            ScheduleSqlJob();
            _scheduler.Start();
        }
        public void Stop()
        {
            if (_scheduler != null) _scheduler.Shutdown(true);
        }
        #endregion
        #region Private methods
        private void ScheduleSqlJob()
        {
            var jobDetails = JobBuilder.Create<Sqljob>()
                                       .WithIdentity("Sqljob")
                                       .Build();
            var trigger = TriggerBuilder.Create()
                                        .StartNow()
                                        .WithCronSchedule("// Get your CRON expression here"))
                                        .Build();
            _scheduler.ScheduleJob(jobDetails, trigger);
        }       
        #endregion
    }
