    var wbMain = FindViewById<WebView>(Resource.Id.wbMain);
    var customWebViewClient = new CustomWebViewClient();
    customWebViewClient.OnPageLoaded += CustomWebViewClient_OnPageLoaded;
    wbMain.SetWebViewClient(customWebViewClient);
    wbMain.LoadUrl("http://the.page.to.load");
