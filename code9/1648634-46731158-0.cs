    public class MainWindow : Window
    {
        private readonly ViewModel _vm = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            SecondaryWindow sw = new SecondaryWindow();
            sw.DataContext = _vm;
            sw.Show();
        }
    }
    public class ViewModel
    {
        public bool IsChecked { get; set; }
    }
