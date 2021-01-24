    public partial class MainWindow : Window
    {
        ViewModel viewModel = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel.BadgeValue = "new value...";
        }
    }
