    void ViewWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        SuspendLayout();
        ViewWebBrowser.Height = ViewWebBrowser.Document.Window.Size.Height;
        ViewWebBrowser.Width = ViewWebBrowser.Document.Window.Size.Width;
        Size = new Size(ViewWebBrowser.Width, ViewWebBrowser.Height);
        ResumeLayout();
    }
