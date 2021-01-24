    Button btnPrintSO = FindViewById<Button>(Resource.Id.btnPrintSO);
    btnPrintSO.Click += delegate
    {
        string URL = ServerDatabaseApi.printSOEndpoint + GlobalVars.selectedSales.DocumentNo;
        webView = new WebView(this);
        CustomWebViewClient client = new CustomWebViewClient(this);
        webView.SetWebViewClient(client);
        webView.Settings.JavaScriptEnabled = true;
        webView.LoadUrl(URL);
        webView.Settings.UseWideViewPort = true;
        webView.Settings.LoadWithOverviewMode = true;
    };
