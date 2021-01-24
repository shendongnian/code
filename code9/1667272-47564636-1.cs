    public class SyncJobListener : IJobListener
    {
        private readonly Action<IJobExecutionContext, JobExecutionException> _syncExecuted;
        public string Name { get; private set; }
        public SyncJobListener(
            Action<IJobExecutionContext, JobExecutionException> syncExecuted
            )
        {
            Name = Guid.NewGuid().ToString();
            _syncExecuted = syncExecuted;
        }
        public void JobToBeExecuted(IJobExecutionContext context)
        {
        }
        public void JobExecutionVetoed(IJobExecutionContext context)
        {
        }
        public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            _syncExecuted(context, jobException);
        }
    }
