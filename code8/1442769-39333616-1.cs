    public sealed partial class MainPage : Page
    {        
        private ViewModel _viewModel;
        public MainPage()
        {
            this.InitializeComponent();
            _viewModel = new ViewModel();
            DataContext = _viewModel;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ButtonClicked();
        }        
    }
