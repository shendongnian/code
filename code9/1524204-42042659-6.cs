    public sealed partial class Buy : Page
    {
        private readonly MainViewModel _viewModel;
        public Buy()
        {
            this.InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }
        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Load();
        }
    }
