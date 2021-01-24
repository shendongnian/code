    using (var client = new WebClient())
    {
        string html = client.DownloadString("https://www.someurl.com");
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);
       //Selecting all the nodes with tagname `span` having "id=example1".
        var nodes = doc.DocumentNode.SelectNodes("//span")
            .Where(d => d.Attributes.Contains("id"))
            .Where(d => d.Attributes["id"].Value == "ctl00_ContentBody_CacheName");
        foreach (HtmlNode node in nodes)
        {
            Console.WriteLine(node.InnerText);
        }
    }
