    public class MainActivity : Activity
        {
            WebView webView;
    
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
    
                MobileBarcodeScanner.Initialize(Application);
    
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);
    
                webView = FindViewById<WebView>(Resource.Id.webView);
                webView.Settings.JavaScriptEnabled = true;
                webView.Settings.AllowFileAccessFromFileURLs = true;
                webView.Settings.AllowUniversalAccessFromFileURLs = true;
                webView.Settings.AllowFileAccess = true;
                webView.AddJavascriptInterface(new QRScannerJSInterface(webView), "CSharpQRInterface");
                webView.LoadUrl("file:///android_asset/scannerPage.html");
    
            }
