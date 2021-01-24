    HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
    html.LoadHtml(new WebClient().DownloadString("http://www.wowhead.com/quest=35151"));
    var root = html.DocumentNode;
    var descriptionHeader = root.Descendants("h2")
        .Where(n => n.GetAttributeValue("class", "")
        .Equals("heading-size-3"))
        .FirstOrDefault();
    var current = descriptionHeader.NextSibling;
    var result = "";
    while(current != null && !current.GetAttributeValue("class", "")
        .Equals("heading-size-3"))
    {
        if (!string.IsNullOrEmpty(current.InnerText))
        {
            result += " "+current.InnerText;
        }
        current = current.NextSibling;
    }
    richTextBox1.Text = result;
