    public class MyService : IService
    {
        public int runCount = 0;
        public void CreateRecurring(id, int? maxTimes = null)
        {
            if (maxTimes.HasValue && (runCount >= maxTimes))
            {
                // Has run enough times now, don't do it again
                return;
            }
            // do something...
        }
    }
    // Run a max of 5 times
    RecurringJob.AddOrUpdate<IService>( recurringId, x =>x.CreateRecurring(id, 5), cron);
