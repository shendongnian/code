    [assembly: ExportRenderer(typeof(MyWebView), typeof(MyWebViewRenderer))]
    namespace FormsIssue.Droid
    {
        public class MyWebViewRenderer:WebViewRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
            {
                base.OnElementChanged(e);
                if (e.OldElement != null || Element == null)
                {
                    return;
                }
                var element = Element as MyWebView;
                Control.Settings.TextZoom = element.ZoomInLevel;
            }
    
            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (Control != null)
                {
                    Control.Settings.BuiltInZoomControls = true;
    
                    //to show the default zoom controls, if you want to use your own button, set this property to false.
                    Control.Settings.DisplayZoomControls = true;
                }
    
                var element = Element as MyWebView;
                Control.Settings.TextZoom = element.ZoomInLevel;
    
                base.OnElementPropertyChanged(sender, e);
            }
        }
    }
