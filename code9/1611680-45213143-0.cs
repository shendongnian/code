    public class UniversalView : UIView, IWKScriptMessageHandler, IWKNavigationDelegate
    {
        [Export("webView:didFinishNavigation:")]
        public void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
        {
            webView.EvaluateJavaScript("callCsharp()", (result, error) =>
            {
                if (error != null) Console.WriteLine(error);
            });
        }
		
