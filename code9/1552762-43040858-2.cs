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
            var excess = DateTime.Now.Minute - 5;
            var span = DateTime.Now.AddMinutes(excess <= 0 ? -excess : 60- excess) - DateTime.Now;
            timer.Interval = span.Milliseconds;
    
            timer.Enabled = true;
        }
    
        protected override void OnStop()
        {
            timer.Enabled = false;
    
            this.WriteToFile("Stopping Service {0}");
        }
    
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            var excess = DateTime.Now.Minute - 5;
            var span = DateTime.Now.AddMinutes(excess <= 0 ? excess + 60 : excess) - DateTime.Now;
            timer.Interval = span.Milliseconds;
            this.WriteToFile(" interval start {0}");
        } 
    }
