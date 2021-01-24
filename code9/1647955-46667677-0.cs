    void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        var img = webBrowser1.Document.GetElementsByTagName("img")
                             .Cast<HtmlElement>().FirstOrDefault();
        var w = img.ClientRectangle.Width;
        var h = img.ClientRectangle.Height;
        img.Style = string.Format("{0}: 100%", w > h ? "Width" : "Height");
    }
