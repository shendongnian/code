    WebView wb = new WebView();
    wb.NavigationStarting += Wb_NavigationStarting;
    ...
    private void NavigateWithHeader(Uri uri)
    {
        var requestMsg = new Windows.Web.Http.HttpRequestMessage(HttpMethod.Get, uri);
        requestMsg.Headers.Add("User-Agent", "blahblah");
        wb.NavigateWithHttpRequestMessage(requestMsg);
        wb.NavigationStarting += Wb_NavigationStarting;
    }
    private void Wb_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
    {
        wb.NavigationStarting -= Wb_NavigationStarting;
        args.Cancel = true;
        NavigateWithHeader(args.Uri);
    }
