    HtmlElementCollection links = webBrowser.Document.GetElementsByTagName("A");
    
    foreach (HtmlElement link in links)
    {
        if (link.InnerText.Equals("My Assigned")) //replace this with how you search for excel
            link.InvokeMember("Click");
    }
