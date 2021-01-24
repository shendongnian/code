    string FixBrokenMarkup(string broken)
    {
        HtmlDocument h = new HtmlDocument()
        {
            OptionAutoCloseOnEnd = true,
            OptionFixNestedTags = true,
            OptionWriteEmptyNodes = true
        };
        h.LoadHtml(broken);
    
        // UPDATED to remove HtmlCommentNode
        foreach (var node in h.DocumentNode.SelectNodes("//comment()"))
        { node.Remove(); }
    
        return h.DocumentNode.SelectNodes("child::*") != null
            //                            ^^^^^^^^^^
            // XPath above: string plain-text or contains markup/tags
            ? h.DocumentNode.WriteTo()
            : string.Format("<span>{0}</span>", broken);
    }
