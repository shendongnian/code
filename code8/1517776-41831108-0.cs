    public class Clock
    {
        private static Clock _instance;
        private Timer timer;
        private Clock()
        {
            timer = new Timer(200);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            GlobalHost.ConnectionManager.GetHubContext<ClockHub>().Clients.All.sendTime(DateTime.UtcNow.ToString());
        }
        public static Clock Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Clock();
                }
                return _instance;
            }
        }
    }
