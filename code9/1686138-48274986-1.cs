    public sealed partial class MyUserControl1 : UserControl
    {
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(MyUserControl1), new PropertyMetadata("default"));
        public MyUserControl1()
        {
            this.InitializeComponent();
        }
        private void WebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            this.Title = sender.DocumentTitle;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Uri uri = new Uri(txbUri.Text.Trim());
                webview.Navigate(uri);
            }
            catch
            {
            }
        }
    }
