    HtmlElementCollection links =  webBrowser1.Document.GetElementsByTagName("a");
    foreach (HtmlElement link in links)
    {
        var linkText = link.InnerText;
        if (linkText.Contains(Keyword.Text) ||
            linkText.Contains(ColorTextbox.Text))
        {
            link.InvokeMember("Click");
            break;
        }
    }
