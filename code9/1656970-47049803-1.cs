        public class CustomWebViewRenderer : ViewRenderer<CustomWebView, UIWebView>
        {
            protected override void OnElementChanged (ElementChangedEventArgs<CustomWebView> e)
            {
                base.OnElementChanged (e);
    
                if (Control == null) {
                    SetNativeControl (new UIWebView ());
                }
                if (e.OldElement != null) {
                    // Cleanup
                }
                if (e.NewElement != null) {
                    var customWebView = Element as CustomWebView;
                    string fileName = Path.Combine (NSBundle.MainBundle.BundlePath, string.Format ("Content/{0}", WebUtility.UrlEncode (customWebView.Uri)));
                    Control.LoadRequest (new NSUrlRequest (new NSUrl (fileName, false)));
                    Control.ScalesPageToFit = true;
                }
            }
        }
