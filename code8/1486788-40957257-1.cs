    public class SimpleInjectorJobFactory : IJobFactory
    {
        private readonly Container _container;
        public SimpleInjectorJobFactory(Container container)
        {
            _container = container;
            _container.Verify();
        }
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
                IJobDetail jobDetail = bundle.JobDetail;
                Type jobType = jobDetail.JobType;
                var job = (IJob)_container.GetInstance(jobType);
                return new LifetimeScopeJobDecorator(job, _container);
        }
        public void ReturnJob(IJob job)
        {
        }
    }
