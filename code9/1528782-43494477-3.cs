    public class JobFactory : IJobFactory
        {
            protected readonly IServiceProvider Container;
    
            public JobFactory(IServiceProvider container)
            {
                Container = container;
            }
    
            public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
            {
                return Container.GetService(bundle.JobDetail.JobType) as IJob;
            }
    
            public void ReturnJob(IJob job)
            {
                (job as IDisposable)?.Dispose();
            }
        }
