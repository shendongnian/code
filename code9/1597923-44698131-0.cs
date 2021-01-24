    JObject jresponse = JObject.Parse(response);
    foreach (JArray row in jresponse["data"])
    {
        List<string> Data = new List<string>();
        foreach (JToken entry in row)
        {
            doc.LoadHtml(entry.ToString());
            HtmlNode node = doc.DocumentNode.SelectSingleNode("//a[@target]");
            Data.Add(node.InnerText);
        }
    }
