    public class MyClass
    {
        private readonly ITimeService _timeService;
    
        public MyClass(ITimeService timeService)
        {
             _timeService = timeService;
        }
    
        public int GetCurrentYear()
        {
            return _timeService.Now.Year;
        }
    }
