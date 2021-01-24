    public partial class MainWindow : Window
    {
        private WPFBrowserView browserView;
        public MainWindow()
        {
            InitializeComponent();
            browserView = new WPFBrowserView();
            browserView.MouseDown += BrowserView_MouseDown;
            this.MainGrid.Children.Add(browserView);
        }
        private void BrowserView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point clickPoint = e.GetPosition(browserView);
            double clickX = clickPoint.X;
            double clickY = clickPoint.Y;
        }
    }
