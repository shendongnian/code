    public class MyJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            if(IsSystemThrottled())
                throw new JobExecutionException(true);
            // your other stuff
        }
    }
