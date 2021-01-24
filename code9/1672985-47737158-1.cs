    WebView webView = new WebView();
    public void GetFirstVideo(string UrlString)
    {
        webView.Navigate(new Uri(UrlString));
        webView.NavigationCompleted -= WebView_NavigationCompletedAsync;  //To avoid multiple subscribe
        webView.NavigationCompleted += WebView_NavigationCompletedAsync;
    }
    private async void WebView_NavigationCompletedAsync(WebView sender, WebViewNavigationCompletedEventArgs args)
    {
        webView.NavigationCompleted -= WebView_NavigationCompletedAsync;  //To stop if there is any re-direct
        var siteHtML = await webView.InvokeScriptAsync("eval", new string[] { "document.documentElement.innerHTML;" });
        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(siteHtML);
        var firstVideoTitle = htmlDocument.DocumentNode.SelectNodes("//div/div/div/div/h3/a")[1].OuterHtml;
    }
