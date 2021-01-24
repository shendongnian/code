    public partial class Window2 : Window
    {
        private DispatcherTimer _DispatcherTimer = new DispatcherTimer();
        public Window2()
        {
            InitializeComponent();
            MouseDown += _MouseDown;
            MouseUp += _MouseUp;
            _DispatcherTimer.Interval = TimeSpan.FromSeconds(1.0);
            _DispatcherTimer.Tick += _DispatcherTimer_Tick;
        }
        private void _DispatcherTimer_Tick(object sender, EventArgs e)
        {
            _DispatcherTimer.Stop();
            Title = DateTime.Now.ToString();
        }
        private void _MouseUp(object sender, MouseButtonEventArgs e)
        {
            _DispatcherTimer.Stop();
        }
        private void _MouseDown(object sender, MouseButtonEventArgs e)
        {
            _DispatcherTimer.Start();
        }
    }
