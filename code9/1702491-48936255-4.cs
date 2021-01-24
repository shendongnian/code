    public string ParseHtmlToString(string inputFilePath)
    {
        var document = new HtmlDocument();
        document.Load(inputFilePath);
        var wantedNodes = document.DocumentNode.SelectNodes("//h4");
        // stop at these tags while walking backwards up the chain
        var stopTags = new string[] { "table", "div", "p" };
        HtmlNode parentNode;
    
        foreach (var node in wantedNodes)
        {
            HtmlNode testNode = node;
            while ((parentNode = testNode.ParentNode) != null)
            {
                if (stopTags.Contains(parentNode.Name))
                {
                    parentNode.ParentNode.ReplaceChild(node, parentNode);
                }
                testNode = parentNode;
            }
        }
    
        return document.DocumentNode.WriteTo();
    }
