    var document = new HtmlDocument();
    document.LoadHtml(html);
    var startNode = document.DocumentNode.SelectSingleNode("//hr[@size='3'][@color='#ff00ff']");
    HtmlNode siblingNode;
    
    while ( (siblingNode = startNode.NextSibling) != null)
    {
    // HtmlAgilityPack normalizes HTML, so works even if HTML source different 
        if (startNode.OuterHtml == siblingNode.OuterHtml)
        {
            siblingNode.Remove();   // end node
            break;
        }
    
        siblingNode.Remove();
    }
    
    startNode.Remove();
