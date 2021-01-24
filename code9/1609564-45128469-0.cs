    public class Scheduler
    {
        static Timer _timer;
        const int dueTimeMin = 1;
        const int periodMin = 1;
        public static void Start(IServiceScopeFactory scopeFactory)
        {
            if (scopeFactory == null) throw new ArgumentNullException("scopeFactory");
            _timer = new Timer(_ =>
            {
                using (var scope = new scopeFactory.CreateScope())
                {
                    scope.GetRequiredService<OperationClass>().DoOperation();
                }
            }, new AutoResetEvent(false), dueTimeMin * 60 * 1000, periodMin * 60 * 1000);
        }
    }
