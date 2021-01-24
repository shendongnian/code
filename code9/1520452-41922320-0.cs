    void webView1_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
    {
        string url = "";
        try { url = args.Uri.ToString(); }
        finally
        {
            address.Text = url;
            appendLog(String.Format("Starting navigation to: \"{0}\".\n", url));
            pageIsLoading = true;
        }
    }
