    WebBrowser myWebBrowser = new WebBrowser();
    private void Form1_Load(object sender, EventArgs e)
    {
        myWebBrowser.DocumentCompleted += myWebBrowser_DocumentCompleted;
        myWebBrowser.DocumentText = System.IO.File.ReadAllText(@"C:\a.htm");
    }
    private void myWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        myWebBrowser.Print();
    }
