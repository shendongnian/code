    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string targetView = ((Button)sender).Tag.ToString();
            _TheFrame.Source = new Uri(targetView, UriKind.Relative);
        }
    }
