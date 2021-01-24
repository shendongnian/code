    public class CustomWebViewClient : WebViewClient
    {
        private SalesDetailView myActivity;
        public bool shouldOverrideUrlLoading(WebView view, string url)
        {
            return false;
        }
        public override void OnPageFinished(WebView view, string url)
        {
            Log.Debug("PRINT", "page finished loading " + url);
            myActivity.doWebViewPrint(url);
            base.OnPageFinished(view, url);
        }
        public CustomWebViewClient(SalesDetailView activity)
        {
            myActivity = activity;
        }
    }
