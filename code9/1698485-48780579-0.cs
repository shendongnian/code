        public class MyWebViewClient: WebViewClient
        {
            public override bool ShouldOverrideUrlLoading(WebView view, string url)
            {
                //if PDF file then use google client to show it
                if (url.ToLower().EndsWith(".pdf"))
                {
                    var newUrl = "https://docs.google.com/viewer?url=" + url;
                    view.LoadUrl(newUrl);
                }
                return true;
            }
        }
