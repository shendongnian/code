    public partial class MainWindow : Window
    {
        private LanguageViewModel vm;
        public MainWindow()
        {
            vm = new LanguageViewModel();
            DataContext = vm;
            InitializeComponent();
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            vm.NextItemFromViewModel();
        }
    }
