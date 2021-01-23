    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        MyViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new MyViewModel();
            DataContext = vm;
            //showColumnChart();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);  // per 5 seconds, you could change it
            timer.Tick += new EventHandler(timer_Tick);
            //timer.IsEnabled = true;
        }
        double i = 1;
        Random random = new Random();
        void timer_Tick(object sender, EventArgs e)
        {
            vm.Add(i, random.NextDouble());
            i += 1;
            if (vm.Power.Count == 250)
            {
                timer.Stop();
            }
        }
        private void showColumnChart()
        {
            lineChart.DataContext = vm;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
    }
