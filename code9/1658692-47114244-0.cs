    HtmlNodeCollection Results = doc.DocumentNode.SelectNodes("//div[@id = 'SearchResults']//div[@class = 'AdvItemBox']");
    StringBuilder strb = new StringBuilder();
    foreach (HtmlNode item in Results)
    {
        HtmlNode itemName = item.SelectSingleNode(".//div[@class = 'AdvNameHeader']");
        strb.AppendFormat("Name: {0}{1}", Regex.Replace(item.InnerText, @"\s+", ""), Environment.NewLine);
    }
