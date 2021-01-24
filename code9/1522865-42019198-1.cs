    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
        ...
        webview.SetWebViewClient(new HybridWebViewClient(this));
        webview.LoadUrl("http://example.com");
       ...
    }
 
