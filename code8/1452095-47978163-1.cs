    private void button1_Click(object sender, EventArgs e)
    {
        webBrowser1.Navigate("http://127.0.0.1/test.html");
    }
     
    private void handlerAbc(Object sender, EventArgs e)
    {
        HtmlElement elm = webBrowser1.Document.GetElementById("abc");
        if (elm == null) return;
        Console.WriteLine("elm.InnerHtml(handlerAbc):" + elm.InnerHtml);
    }
     
    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        /* Get the original HTML (method 1)*/
        System.IO.StreamReader getReader = new System.IO.StreamReader(webBrowser1.DocumentStream, System.Text.Encoding.Default);
        string htmlA = getReader.ReadToEnd(); // htmlA can only extract original HTML
     
        /* Get the original HTML (method 2)*/
        string htmlB = webBrowser1.DocumentText; // htmlB can only extract original HTML
     
        /* You can use the following method to extract the 'onChanged' AJAX content*/
        HtmlElement elm = webBrowser1.Document.GetElementById("abc"); // Get "abc" element by ID
        Console.WriteLine("elm.InnerHtml(DocumentCompleted):" + elm.InnerHtml);
        if (elm != null)
        {
            // Listen on 'abc' onpropertychange event
            elm.AttachEventHandler("onpropertychange", new EventHandler(handlerAbc));
        }
     
    }
