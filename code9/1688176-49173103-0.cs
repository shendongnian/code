    public class MyWKUIDelegate : WKUIDelegate
    {
        public override WKWebView CreateWebView(WKWebView webView, WKWebViewConfiguration configuration, WKNavigationAction navigationAction, WKWindowFeatures windowFeatures)
        {
            var url = navigationAction.Request.Url;
            if (navigationAction.TargetFrame == null)
            {
                webView.LoadRequest(navigationAction.Request);
            }
            return null;
        }
    }
