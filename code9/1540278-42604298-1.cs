    public partial class MainWindow : Window
    {
        ViewModel viewModel = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
        private void Properties1_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new PWMProperties();
            newWindow.Owner = this;
            newWindow.DataContext = viewModel; 
            newWindow.Show(); 
        }
    }
