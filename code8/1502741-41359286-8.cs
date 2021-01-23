    [assembly: ExportRenderer(typeof(MyWebView), typeof(MyWebViewRenderer))]
    namespace FormsIssue.Droid
    {
        public class MyWebViewRenderer : WebViewRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
            {
                base.OnElementChanged(e);
                if (e.OldElement != null || Element == null)
                {
                    return;
                }
    
                //Initial zoom
                var element = Element as MyWebView;
                element.ZoomInLevel = element.ZoomOutLevel = Control.Settings.TextZoom;
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
                //ZoomIn
                if (e.PropertyName == "ZoomInLevel")
                    element.ZoomOutLevel = Control.Settings.TextZoom = element.ZoomInLevel;
                //ZoomOut
                else if (e.PropertyName == "ZoomOutLevel")
                    element.ZoomInLevel = Control.Settings.TextZoom = element.ZoomOutLevel;
    
                base.OnElementPropertyChanged(sender, e);
            }
        }
    }
