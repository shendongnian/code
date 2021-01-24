    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new NavigationViewModel();
            Pages.Content = new MenuView() { DataContext = new MenuViewModel(viewModel) };
            this.DataContext = viewModel;
        }
    }
