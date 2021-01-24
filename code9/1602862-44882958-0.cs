    public partial class App : Application
    {
        private Timer timer;
        private AutoResetEvent autoEvent = new AutoResetEvent(false); // Configures the state of the event
        public App() 
        {
            this.InitializeComponent();
            // Start timer
            this.timer = new Timer(this.CheckTime, this.autoEvent, 1000, 60000);
        }
        // ViewModels will subscribe to this
        public static event EventHandler<TimeEventArgs> TimeEvent;
        // The TimerCallback needed for the timer. The parameter is not practically needed but needed for the TimerCallback signature.
        private void CheckTime(object state) =>
            this.OnRaiseTimeEvent(new TimeEventArgs(DateTime.Now.ToString("HH:mm")));
        
        // Invokes the event
        private void OnRaiseTimeEvent(TimeEventArgs e) => 
            TimeEvent?.Invoke(this, e);
    }
