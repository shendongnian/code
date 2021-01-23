    [assembly: Xamarin.Forms.ExportRenderer(typeof(SomethingWebView), typeof(Your.iOS.Namespace.SomethingWebViewRenderer))]
    namespace Your.iOS.Namespace.Renderer {
    public class SomethingWebViewRenderer : WebViewRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e) {
            base.OnElementChanged(e);
            if(e.OldElement == null) {
                Control.Settings.JavaScriptEnabled = true;
                Control.SetWebViewClient(new SomethingWebViewClient());
                Control.SetWebChromeClient(new SomethingWebChromeClient());
            }
        }
    }
    internal class SomethingWebViewClient : WebViewClient {
        public override void OnPageFinished(Android.Webkit.WebView view, string url) {
            base.OnPageFinished(view, url);
            view.LoadUrl("javascript:{(function() { window.alert('something'); })()};");
        }
    }
    public class SomethingWebChromeClient : WebChromeClient {
        public override bool OnJsAlert(Android.Webkit.WebView view, string url, string message, JsResult result) {
            if(message.StartsWith("something") { //This is where you would look for your magic string, anything starting with your magic string is what you would extract and/or act on
                //Do something....
                result.Cancel(); //This cancels the JS alert (there are other talked about methods of doing this but this works for me)
                return true; //This tells the WebView "we got this"
            }
            return base.OnJsAlert(view, url, message, result); //Let the WebView handle this since we did not find out special string
        }
    }
    }
