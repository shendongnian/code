    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            Action someMethod = new Action(() =>
            {
                Console.WriteLine("Timed Task - Will run now");
            });
            // Schedule schedule = new Schedule(someMethod);
            // schedule.ToRunNow();
            this.Schedule(someMethod).ToRunNow();
        }
    }
