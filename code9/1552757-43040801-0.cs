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
    
            timer.Interval = 1000 * 60; // 60 000 ms => 1 minute
    
            timer.Enabled = true;
        }
    
        protected override void OnStop()
        {
            timer.Enabled = false;
    
            this.WriteToFile("Stopping Service {0}");
        }
    
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            var curTime = DateTime.Now; // Get current time
            if (curTime.Minute == 5) // If now 5 min of any hour
            {
                // Some action
                this.WriteToFile(" interval start {0}");
            }
        } 
    }
