    class DailyTaskRunner
        {
            private DateTime _lastDateRun = DateTime.MinValue;
    
            Timer _timer;
    
            public DailyTaskRunner(TimeSpan timeOfDay, Action task)
            {
                _timer = new Timer((o) =>
                {
                    if (DateTime.Now.TimeOfDay >= timeOfDay && DateTime.Today != _lastDateRun)
                    {
                        _lastDateRun = DateTime.Today;
                        task();
                    }
    
                }, null, 1, 1);
            }
        }
    
        void TestTask()
                {
                    DailyTaskRunner r = new DailyTaskRunner(TimeSpan.FromHours(8) + TimeSpan.FromMinutes(43), () => Console.WriteLine("I'm a daily task, run at " + DateTime.Now.TimeOfDay.ToString()));
        
                    Console.ReadLine();
                }
