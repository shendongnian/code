        using Android.Webkit;
        public class CustomWebChromeClient : WebChromeClient { 
        
            public override void OnCloseWindow(Android.Webkit.WebView window)
            {
                base.OnCloseWindow(window);
                //Your favorite logging library call.
            }
        
        }
