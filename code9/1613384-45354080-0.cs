    private async void WebView_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
    {    
       string scriptToLoad = File.ReadAllText("Apps.Webapp/JS/jquery-3.2.1.min.js");
       string[] arguments = { scriptToLoad };
       await WebBrowserWizzio.InvokeScriptAsync("eval", arguments);
    }
