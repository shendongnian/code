    class MyDelegate : UIWebViewDelegate
    {
        UIScrollView mainView;
        public MyDelegate(UIScrollView view) {
            mainView = view;
        }
        public override void LoadingFinished(UIWebView webView)
        {
            string result = webView.EvaluateJavascript("document.body.offsetHeight;");
            mainView.AddConstraints(webView.Height().EqualTo(Convert.ToInt64(result)));
        }
    }
