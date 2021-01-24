    public IEnumerable<HtmlElement> GetElementByTagAndContent(string tag, string content)
    {
        foreach (HtmlElement elem in browser.Document.GetElementsByTag(tag))
        {
            if (elem.InnerText == content)
                yield return elem
        }
    }
