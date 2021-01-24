    IPAddress tempip;
    int port;
    List<IPEndPoint> proxies = null;
    using (var client = new HttpClient())
    {
        var doc = new HtmlAgilityPack.HtmlDocument();
        XNamespace ns = "http://www.w3.org/2005/Atom";
        var xml = await client.GetStringAsync("http://www.proxyserverlist24.top/feeds/posts/default");
        var xDoc = XDocument.Parse(xml);
        proxies = xDoc.Descendants(ns + "entry")
            .Select(x => (string)x.Element(ns + "content"))
            .SelectMany(x =>
            {
                doc.LoadHtml(x);
                return doc.DocumentNode.SelectNodes("//span[not(span)]")
                            .SelectMany(n => n.Descendants())
                            .Select(n => n.InnerText.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                            .Where(n => n.Length == 2)
                            .Where(n => IPAddress.TryParse(n[0], out tempip))
                            .Where(n => int.TryParse(n[1], out port))
                            .Select(n => new IPEndPoint(IPAddress.Parse(n[0]), int.Parse(n[1])));
            })
            .ToList();
    }
