    HtmlWeb htmlWeb = new HtmlWeb();
    htmlWeb.UsingCache = false;
    int i = 0;
    while (i < 300)
    {
        var uri = new Uri($"yoururl?z={Guid.NewGuid()}");
        i++;
        HtmlAgilityPack.HtmlDocument LoadWebsite = htmlWeb.Load(uri.AbsoluteUri);
        HtmlNode rateNode = LoadWebsite.DocumentNode.SelectSingleNode("//div[@class='the-value']");
        string rate = rateNode.InnerText;
        Console.WriteLine(i + ". " + rate);
        Thread.Sleep(1000);
    }
