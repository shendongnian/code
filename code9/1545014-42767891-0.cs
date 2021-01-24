      public class PdfController : UIViewController
    {
        public PdfController(string pdfPath)
        {
            NavigationItem.LeftBarButtonItem = new NavBarButton("Back", (sender, args) =>
            {
                NavigationController.PopViewController(true);
            });
            var webView = new UIWebView(View.Bounds);
            View.AddSubview(webView);
            webView.LoadRequest(new NSUrlRequest(new NSUrl(pdfPath, false)));
            webView.ScalesPageToFit = true;
        }
    }
