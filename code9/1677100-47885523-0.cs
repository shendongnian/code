    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html); // pass in your HTML string
    foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
    {
        string text = link.InnerText;
        if (text.Contains('|'))
            link.InnerHtml = text.Remove(text.IndexOf('|')); // you can't modify InnerText directly but this works
    }
    string result = doc.DocumentNode.OuterHtml; // your desired result
