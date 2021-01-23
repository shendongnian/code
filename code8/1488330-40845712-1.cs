    public partial class RollWindow : Window
    {
        public RollWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // You might want to replace this with a ViewModel locator
            DataContext = new RollsViewModel();
        }
    }
