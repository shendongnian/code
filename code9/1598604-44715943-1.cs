    foreach (var item in en)
    {
        foreach (HtmlNode child in item.ChildNodes)
        {
            item.ParentNode.InsertBefore(child, item);
        }
        item.Remove();
    }
