    public partial class MainWindow : Window
    {
        private StackPanel _stackPanel;
        public MainWindow()
        {
            InitializeComponent();
            _stackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            Content = _stackPanel;
            AddEllipse();
            AddEllipse();
            AddEllipse();
        }
        public void AddEllipse()
        {
            var ellipse = new Ellipse()
            {
                Style = FindResource("YellowEllipseWithBlackBorder") as Style
            };
            _stackPanel.Children.Add(ellipse);
        }
    }
