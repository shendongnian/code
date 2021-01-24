    public partial class MainWindow:Window
    {
        Codec codec = new Codec();
    
        public MainWindow();
        {
            InitializeComponent();
        }
    
        private void btnAdvanced_Click(object sender, RoutedEventArgs e)
        {
            _mainframe.NavigationService.Navigated += NavigationService_Navigated;
            _mainframe.NavigationService.Navigate(
                new Uri("Advanced.xaml", UriKind.Relative), codec);
        }
        private void NavigationService_Navigated(object sender, NavigationEventArgs e)
        {
            ((AdvancedPage)e.Content).Codec = (Codec)e.ExtraData;
            _mainframe.NavigationService.Navigated -= NavigationService_Navigated;
        }
    
        //there are various shortcut buttons below here
    }
