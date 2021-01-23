    HtmlElement FindLink(string innerText)
    {
        foreach (HtmlElement link in webBrowser.Document.GetElementsByTagName("a"))
        {
            if (link.InnerText.Equals("Google Me"))
            {
                return link;
            }
        }
    }
