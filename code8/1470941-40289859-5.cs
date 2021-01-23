    public class QRScannerJSInterface : Java.Lang.Object
        {
            QRScanner qrScanner;
            WebView webView;
    
            public QRScannerJSInterface(WebView webView)
            {
                this.webView = webView;
                qrScanner = new QRScanner();
            }
    
            [Export("ScanQR")]
            public void ScanQR()
            {
                qrScanner.ScanQR()
                    .ContinueWith((t) =>
                    {
                        //var js = string.Format("getQRValue('{0}');", t.Result);
                        //webView.LoadUrl("javascript:" + js);
                        //call the Javascript method here with "result" as its parameter to get the scanned value
                        if (t.Status == TaskStatus.RanToCompletion)
                            webView.LoadUrl(@"javascript:getQRValue('" + t.Result + "')");
                    });
            }
        }
