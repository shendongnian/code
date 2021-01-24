    foreach (HtmlAgilityPack.HtmlNode pNode in html)
    {
        HtmlNode textNode = doc.CreateElement(@"\color[RED]");
        pNode.ParentNode.InsertBefore(textNode, pNode);
    }
