    public static class WebViewExtensions  
    {
        public static void ResizeToContent(this WebView webView)
        {
            var heightString = webView.InvokeScript("eval", new[] {"document.body.scrollHeight.toString()" });
            int height;
            if (int.TryParse(heightString, out height))
            {
                webView.Height = height;
            }
        }
    }
    public Page()  
    {
        MyWebView.NavigationCompleted += (sender, args) => sender.ResizeToContent();
        MyWebView.Navigate(new Uri("index.html"));
    }
