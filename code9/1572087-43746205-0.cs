    public class CustomWebViewClient : WebViewClient
    {
	    public event EventHandler<bool> OnPageLoaded;
	    public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
	    {
		    view.LoadUrl(request.Url.ToString());
		    return true;
	    }
	    public override void OnPageStarted(WebView view, string url, global::Android.Graphics.Bitmap favicon)
	    {
		    base.OnPageStarted(view, url, favicon);
	    }
	    public override void OnPageFinished(WebView view, string url)
	    {
	    	OnPageLoaded?.Invoke(this, true);
	    }
	    public override void OnReceivedError(WebView view, IWebResourceRequest request, WebResourceError error)
	    {
		    OnPageLoaded?.Invoke(this, false);
	    }
    }
