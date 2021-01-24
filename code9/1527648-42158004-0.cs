    public class JobFactory : IJobFactory
    {
        protected readonly TypeFactory Factory;
        public JobFactory(TypeFactory factory)
        {
            Factory = factory;
        }
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return Factory.Create(bundle.JobDetail.JobType) as IJob;
        }
        public void ReturnJob(IJob job)
        {
            Factory.Release(job);
        }
    }
