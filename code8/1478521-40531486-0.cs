    foreach (var deal in deals) {
        var node = xdoc.CreateNode("element", "DealNo", "");
        node.InnerText = deal.DealNo;
        var singleNode = xdoc.SelectSingleNode("Resource/ResourceID/ResourceBody");
        singleNode.AppendChild(node);
    
        node = xdoc.CreateElement("ItemList");
        singleNode = xdoc.SelectSingleNode("Resource/ResourceID/ResourceBody");
        
        // Add deal items here...
        foreach (string dealItem in deal.DealItem) {
            var dealItemNode = xdoc.CreateNode("element", "Item", "");
            dealItemNode.InnerText = dealItem;
            node.AppendChild(dealItemNode);
        }
    
        singleNode.AppendChild(node);
    }
