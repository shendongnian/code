    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer timer = new System.Timers.Timer();
    
        public Service1()
        {
            InitializeComponent();
        }
    
        protected override void OnStart(string[] args)
        {
            this.WriteToFile("Starting Service {0}");
    
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
    
            timer.Interval = 1000 * 30; // 30 000 ms => 30 seconds
    
            timer.Enabled = true;
        }
    
        protected override void OnStop()
        {
            timer.Enabled = false;
    
            this.WriteToFile("Stopping Service {0}");
        }
    
        private int lastHour = -1;
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            var curTime = DateTime.Now; // Get current time
            if (lastHour != curTime.Hour && curTime.Minute == 5) // If now 5 min of any hour
            {
                lastHour = curTime.Hour;
                // Some action
                this.WriteToFile(" interval start {0}");
            }
        } 
    }
