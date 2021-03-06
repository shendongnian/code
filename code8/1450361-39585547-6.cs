    [assembly: Xamarin.Forms.ExportRenderer(typeof(SomethingWebView), typeof(Your.Droid.Namespace.SomethingWebViewRenderer))]
    namespace Your.Droid.Namespace.Renderer {
    public class SomethingWebViewRenderer : WebViewRenderer {
        protected override void OnElementChanged(VisualElementChangedEventArgs e) {
            base.OnElementChanged(e);
            if(e.OldElement == null) {
                Delegate = new SomethingWebViewDelegate();
            }
        }
    }
    internal class SomethingWebViewDelegate : UIWebViewDelegate {
        public override void LoadingFinished(UIWebView webView) {
            string something = webView.EvaluateJavascript("(function() { return 'something'; })()");
        }
    }
    }
