    webView.Browser.FinishLoadingFrameEvent += delegate (object sender, FinishLoadingEventArgs e)
    {
        if (e.IsMainFrame)
        {
            DOMDocument document = e.Browser.GetDocument();
            var html = document.DocumentElement.InnerHTML;
            System.IO.File.WriteAllText("hmtl.txt", html);
            waitEvent.Set();
        }
    };
