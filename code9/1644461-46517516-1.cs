    foreach (HtmlAgilityPack.HtmlNode pNode in html)
    {
        HtmlNode textNode = doc.CreateTextNode(@"\color[RED]");
        pNode.ParentNode.InsertBefore(textNode, pNode);
    }
