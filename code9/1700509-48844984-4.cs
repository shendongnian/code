    public partial class GeckoBrowser : UserControl
    {
        public static readonly DependencyProperty UriProperty =
            DependencyProperty.Register("Uri", typeof(string), typeof(GeckoBrowser), new FrameworkPropertyMetadata(null));
        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }
        
        public GeckoBrowser()
        {
            InitializeComponent();
            Xpcom.Initialize("Firefox");
            Loaded += GeckoBrowser_Loaded;
        }
        
        private void GeckoBrowser_Loaded(object sender, RoutedEventArgs e)
        {
            WindowsFormsHost host = new WindowsFormsHost();
            GeckoWebBrowser browser = new GeckoWebBrowser();
            browser.Navigate(Uri);
            host.Child = browser;
            MyBorder.Child = host;
        }
    }
