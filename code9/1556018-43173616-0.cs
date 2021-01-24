    public class ScheduledJobRegistry: Registry
    {
        public ScheduledJobRegistry(DateTime appointment)
        {
          IJob job = new SampleJob();
          JobManager.AddJob(job, s => s.ToRunOnceIn(5).Seconds());
        }
    }
