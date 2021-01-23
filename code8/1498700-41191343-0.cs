    using (var client = new HttpClient())
    {
        var html = await client.GetStringAsync("https://who.is/whois/google.com/");
        var doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(html);
        var nodes = doc.DocumentNode.SelectNodes("//*[@class='col-md-4 queryResponseBodyKey']");
        var results = nodes.ToDictionary(n=>n.InnerText, n=>n.NextSibling.NextSibling.InnerText);
        //print
        foreach(var kv in results)
        {
            Console.WriteLine(kv.Key + " => " + kv.Value);
        }
    }
