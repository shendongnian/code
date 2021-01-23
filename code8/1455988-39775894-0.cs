    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ViewModel viewModel = new ViewModel();
            DataContext = viewModel;
        }
    }
