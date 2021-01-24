    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer _timer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            _timer.Interval = TimeSpan.FromSeconds(0.2); //wait for the other click for 200ms
            _timer.Tick += _timer_Tick;
        }
        private void lv_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            {
                _timer.Stop();
                System.Diagnostics.Debug.WriteLine("double click"); //handle the double click event here...
            }
            else
            {
                _timer.Start();
            }
        }
        private void _timer_Tick(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("click"); //handle the Click event here...
            _timer.Stop();
        }
    }
----------
    <ListBox PreviewMouseLeftButtonDown="lv_PreviewMouseLeftButtonDown" ... />
