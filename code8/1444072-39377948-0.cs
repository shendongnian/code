    public static string[] ParseHtmlSplitTables(string htmlString)
    {
        string[] result = new string[] { };
        if (!String.IsNullOrWhiteSpace(htmlString))
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlString);
            var tableNodes = doc.DocumentNode.SelectNodes("//table");
            if (tableNodes != null)
            {
                result = Array.ConvertAll<HtmlNode, string>(tableNodes.ToArray(), n => n.OuterHtml);
            }
        }
        return result;
    }
