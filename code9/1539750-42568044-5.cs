    class MainWindow : Window
    {
        private readonly ViewModel _viewModel = new ViewModel();
        public MainWindow()
        {
            DataContext = _viewModel;
            InitializeComponent();
        }
        private void btnPopulate_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                for (int n = 0; n < 100; n++)
                {
                    // simulates some costly computation
                    Thread.Sleep(50);
                    // periodically, update the progress
                    _viewModel.ProgressValue = n;
                }
            });
        }
    }
