    public static HtmlNode Closest(this HtmlNode node, string search)
    {
        search = search.ToLower();
        while (node.ParentNode != null)
        {
            if (node.ParentNode.Name.ToLower() == search) return node.ParentNode;
            node = node.ParentNode;
        }
        return null;
    } 
