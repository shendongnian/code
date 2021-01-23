    using My.Project.iOS.Renderers;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    
    [assembly: ExportRenderer(typeof(WebView), typeof(CustomWebViewRenderer))]
    
    namespace My.Project.iOS.Renderers
    {
        internal class CustomWebViewRenderer : Xamarin.Forms.Platform.iOS.WebViewRenderer
        {
            protected override void OnElementChanged(VisualElementChangedEventArgs e)
            {
                base.OnElementChanged(e);
    
                var view = NativeView as UIKit.UIWebView;
    
                view.ScrollView.ScrollEnabled = false;
                view.ScrollView.Bounces = false;
            }
        }
    }
