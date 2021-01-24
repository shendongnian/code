    public override void OnPageStarted(WebView view, string url, Android.Graphics.Bitmap favicon)
    {
        base.OnPageStarted(view, url, favicon);
        // Code to show the progress bar
    }
    
    public override void OnPageFinished(WebView view, string url)
    {
        base.OnPageFinished(view, url);
    	// Code to hide the progress bar
    }
