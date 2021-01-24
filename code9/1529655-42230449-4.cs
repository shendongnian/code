    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new NavigationViewModel();
            viewModel.SelectedViewModel = new MenuViewModel(viewModel);
            this.DataContext = viewModel;
        }
    }
