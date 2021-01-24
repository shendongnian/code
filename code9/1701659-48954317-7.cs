    var document = new HtmlDocument();
    document.LoadHtml(html);
    var startNode = document.DocumentNode.SelectSingleNode("//hr[@size='3'][@color='#ff00ff']");
    // account for mismatched quotes in HTML source
    var quotesRegex = new Regex("[\"']");
    var startNodeNoQuotes = quotesRegex.Replace(startNode.OuterHtml, "");
    HtmlNode siblingNode;
    
    while ( (siblingNode = startNode.NextSibling) != null)
    {
        siblingNode.Remove();
        if (quotesRegex.Replace(siblingNode.OuterHtml, "") == startNodeNoQuotes)
        {
            break;  // end node
        }
    }
    
    startNode.Remove();
