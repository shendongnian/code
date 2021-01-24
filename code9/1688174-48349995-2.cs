    class AllowAllDelegate : WKNavigationDelegate
    {
        public override void DecidePolicy(WKWebView webview, WKNavigationAction action, Action<WKNavigationActionPolicy> actionCallback)
        {
            // do some checks if you want to filter actions 
            actionCallback(WKNavigationActionPolicy.Allow);
        }
    }
