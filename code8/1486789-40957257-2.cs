    public static class QuartzScheduler
    {
        private static Container _quartzContainer { get; set; }
        private static void Initialize()
        {
            Container container = new Container();
            container.RegisterLifetimeScope<IUnitOfWork, SqlUnitOfWork>();
            container.Register<ILogger, NLogLogger>();
            //To enable lifetime scoping, please make sure the EnableLifetimeScoping extension method is called during the configuration of the container.
            container.EnableLifetimeScoping();
            container.Verify();
            _quartzContainer = new Container();
            var schedulerFactory = new StdSchedulerFactory();
            _quartzContainer.RegisterSingle<IJobFactory>(() => new SimpleInjectorJobFactory(container));
            _quartzContainer.RegisterSingle<ISchedulerFactory>(schedulerFactory);
            _quartzContainer.Register<IScheduler>(() =>
            {
                var scheduler = schedulerFactory.GetScheduler();
                scheduler.JobFactory = _quartzContainer.GetInstance<IJobFactory>();
                return scheduler;
            }
            );
            _quartzContainer.Verify();
