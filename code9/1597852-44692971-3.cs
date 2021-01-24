        public LoadURI()
        {
            webView.Navigate(new Uri("https://www.bing.com/"));
            webView.NavigationCompleted += webView_NavigationCompletedAsync;
        }
        string siteHtML = null;
        private async void webView_NavigationCompletedAsync(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            siteHtML = await webView.InvokeScriptAsync("eval", new string[] { "document.documentElement.outerHTML;" });
        }
