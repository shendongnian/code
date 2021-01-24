    internal class CountJobListener : IJobListener
    {
        public void JobToBeExecuted(IJobExecutionContext context)
        {
        }
        public void JobExecutionVetoed(IJobExecutionContext context)
        {
        }
        public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            if (GetCount() >= 4)
            {
                context.Scheduler.Shutdown();
            }
        }
        private int GetCount()
        {
            throw new NotImplementedException();
        }
        public string Name { get { return "CountJobListener"; } }
    }
