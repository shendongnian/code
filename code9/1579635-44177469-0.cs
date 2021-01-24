    [assembly: ExportRenderer(typeof(WebView), typeof(WebViewRenderer))]
    namespace DisplayEpub.UWP{
    public class CustomWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var customWebView = Element as WebView;
                Control.Source = new Uri(string.Format("ms-appx-web:///Assets/pdfjs/web/viewer.html"));
            }
        }
    }
    }
