    protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        base.OnElementPropertyChanged(sender, e);
        if (e.PropertyName == "Uri")
        {
            var webView = new Android.Webkit.WebView(_context);
            webView.Settings.JavaScriptEnabled = true;
            SetNativeControl(webView);
            Control.AddJavascriptInterface(new JSBridge(this), "jsBridge");
            Control.LoadUrl(Element.Uri);                
            InjectJS(JavaScriptFunction);                
        }
    }
