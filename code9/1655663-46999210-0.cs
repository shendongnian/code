    [Activity(Label = "DroidWebview", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        WebView myWebView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
    
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
    
            myWebView = FindViewById<WebView>(Resource.Id.webview);
            myWebView.Settings.JavaScriptEnabled = true;
            myWebView.SetWebViewClient(new MyWebViewClient());
    
            myWebView.LoadUrl("https://stackoverflow.com/questions/46978983/xamarin-android-save-webview-in-pdf");
    
            Button myPrintButton = FindViewById<Button>(Resource.Id.myPrintButton);
            myPrintButton.Click += (sender, e) =>
            {
                var printManager = (PrintManager)GetSystemService(PrintService);
                string fileName = "MyPrint_" + Guid.NewGuid().ToString() + ".pdf";
                var printAdapter = myWebView.CreatePrintDocumentAdapter(fileName);
                PrintJob printJob = printManager.Print("MyPrintJob", printAdapter, new PrintAttributes.Builder().Build());
            };
        }
    }
    
    public class MyWebViewClient : WebViewClient
    {
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            view.LoadUrl(url);
            return false;
        }
    }
