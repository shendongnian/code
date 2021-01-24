    public partial class MainWindow : Window
    {
        private _viewModel = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.InitializeComponent();
            this.DataContext = _viewModel;
        }
    }
    public void CalculateClick(object sender, RoutedEventArgs e)
    {
        _viewModel.CalculateClick(Sender, e);
    }
