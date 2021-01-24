    private void BuildTree(ItemCollection itemCollection, XElement xElement)
    {
        var item = new TreeViewItem() { Header = xElement.Name.LocalName };
        itemCollection.Add(item);
        foreach (var xElem in xElement.Elements())
        {
            BuildTree(item.Items, xElem);
        }
        item = new TreeViewItem() { Header = xElement.Value };
        itemCollection.Add(item);
        foreach (var xElem in xElement.Elements()) //<---
        {
            BuildTree(item.Items, xElem);
        }
    }
