    private static string GetAskedText(HtmlDocument doc)
    {
        if (doc == null)
            return "document-null";
        IEnumerable<mshtml.HTMLDivElement> divs = doc.GetElementsByTagName("div")
            .OfType<HtmlElement>()
            .Select(e => e.DomElement as mshtml.HTMLDivElement);
        foreach (var div in divs)
        {
            if (string.IsNullOrWhiteSpace(div?.className))
                continue;
            if (div.className.Trim().ToLower() != "user-info")
                continue;
            var spans = div.getElementsByTagName("span").OfType<mshtml.HTMLSpanElement>();
            foreach (var span in spans)
            {
                if (string.IsNullOrWhiteSpace(span?.className))
                    continue;
                if (span.className == "relativetime")
                {
                    return span.innerText;
                }
            }
        }
        return "not-found";
    }
