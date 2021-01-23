    public sealed partial class App : Application
    {
        public static new App Current => (App)Application.Current;
        public event EventHandler IsIdleChanged;
        private DispatcherTimer idleTimer;
        private bool isIdle;
        public bool IsIdle
        {
            get
            {
                return isIdle;
            }
            private set
            {
                if (isIdle != value)
                {
                    isIdle = value;
                    IsIdleChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            idleTimer = new DispatcherTimer();
            idleTimer.Interval = TimeSpan.FromSeconds(10);  // 10s idle delay
            idleTimer.Tick += onIdleTimerTick;
            Window.Current.CoreWindow.PointerMoved += onCoreWindowPointerMoved;
        }
        private void onIdleTimerTick(object sender, object e)
        {
            idleTimer.Stop();
            IsIdle = true;
        }
        private void onCoreWindowPointerMoved(CoreWindow sender, PointerEventArgs args)
        {
            idleTimer.Stop();
            idleTimer.Start();
            IsIdle = false;
        }
    }
