    public MainPage()
    {
        this.InitializeComponent();
        MyWebView.NavigationStarting += MyWebViewOnNavigationStarting;
    }
    private void MyWebViewOnNavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
    {
        string navigatingUri = args.Uri.ToString();
            
    }
