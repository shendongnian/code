    var browser = new CefSharp.OffScreen.ChromiumWebBrowser(htmlURL);
    // wait the browser to finish loading the html file   
    using (var waitHandle = new System.Threading.AutoResetEvent(false))
    {
        EventHandler<LoadingStateChangedEventArgs> loadingHandler = null;
        loadingHandler = (sender, e) =>
        {
            if (!e.IsLoading)
            {
                if (browser != null)
                {
                    browser.LoadingStateChanged -= loadingHandler;
                }
                waitHandle.Set();
            }
        };
        browser.LoadingStateChanged += loadingHandler;
        waitHandle.WaitOne();
    }
    var bitmap = browser.Bitmap; // bitmap not null 
