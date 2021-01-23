    string url = "your URL";
                    HtmlWeb web = new HtmlWeb();
                    web.PreRequest = delegate (HttpWebRequest webRequest)
                    {
                        webRequest.Timeout = 15000;
                        return true;
                    };
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    List<HtmlNode> findclasses = doc.DocumentNode.Descendants("div").Where(d =>
            d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("YourClassName")
        ).ToList();
