    public partial class MainWindow : Window
    {
        private readonly System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer()
        public MainWindow()
        {
            InitializeComponent();  
            _timer.Interval = 500; // 500ms.
            _timer.Elapsed += ElapsedCallback;
            _timer.Start();  
        }
    
        private void ElapsedCallback(object sender, EventArgs e)
        {
            MainGrid.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
            r = ++r % 0xFF; // prevent overlfow.
            g = ++g % 0xFF;
            b = ++g % 0xFF;
        }
        private void xBtn_Click(object sender, RoutedEventArgs e)
        {
            xCoordinate.Background = new SolidColorBrush(Colors.Red);
        }
    
        private void yBtn_Click(object sender, RoutedEventArgs e)
        {
            yCoordinate.Background = new SolidColorBrush(Colors.Blue);
        }
    
        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = Mouse.GetPosition(Application.Current.MainWindow);
            xCoordinate.Content = point.X;
            yCoordinate.Content = point.Y;
    
        }
    }
