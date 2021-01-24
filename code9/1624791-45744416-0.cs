    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(htmlstring);
    var tables = doc.DocumentNode
                 .SelectNodes("//span[@class='someOtherClass']/following::table").ToList();
    foreach (var table in tables)
    {
        var list = table.Descendants("tr")
                        .Select(tr => tr.Descendants("td")
                        .Select(td => td.InnerText).ToList())
                        .ToList();
    }
