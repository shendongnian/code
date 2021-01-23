    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
    
        private void LoadLocalHtml()
        {
            MyWebView.Navigate(new Uri("ms-appx-web:///Assets/demo.html"));
        }
    }
