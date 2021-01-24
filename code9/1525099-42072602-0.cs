    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame0.Navigated += Frame0_Navigated;
        }
        private void Frame0_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            SubPage subPage = frame0.Content as SubPage;
            if (subPage != null)
            {
                TextBox textName = subPage.textName;
            }
            //remove the event handler
            frame0.Navigated -= Frame0_Navigated;
        }
    }
