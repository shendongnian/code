    public class Scheduler
    {
        private readonly ISchedulerFactory _factory;
        private static Scheduler _instance;
        public static Scheduler Instance => _instance;
        public Task<IScheduler> Current => _factory.GetScheduler();
        public Scheduler(ISchedulerFactory factory)
        {
            _factory = factory;
            if (_instance == null)
            {
                _instance = this;
            }
        }
    }
