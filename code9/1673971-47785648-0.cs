    private async void wv_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
    {
        var WebViewWidth = await wv.InvokeScriptAsync("eval", new string[] { "GetWebViewWidth()" });
        var WebViewHeight = await wv.InvokeScriptAsync("eval", new string[] { "GetWebViewHeight()" });
        wv.Height = Convert.ToInt64(WebViewWidth);
        wv.Width = Convert.ToInt64(WebViewHeight);
    }
