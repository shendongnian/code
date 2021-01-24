    public class HybridWebViewClient : WebViewClient
    {
        Context context;
        public HybridWebViewClient(Context context)
        {
            this.context = context;
        }
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            var tel = "tel:";
            if (url != null)
            {
                if (url.StartsWith(tel))
                {
                    var uri = Android.Net.Uri.Parse(url);
                    var intent = new Intent(Intent.ActionDial, uri);
                    context.StartActivity(intent);
                }
            }
            return true;
        }
    }
