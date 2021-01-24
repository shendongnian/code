    Item[] items = ...;
    Dictionary<int, TreeItem> result = new Dictionary<int, TreeItem>();
    foreach (var item in items.OrderBy(x => x.ParentID ?? -1))
    {
        TreeItem current; 
        if (item.ParentID.HasValue)
        {
            TreeItem parent = result[item.ParentID]; // guaranteed to exist due to order
            current = new TreeItem(item.ID, parent);            
            parent.Children.Add(current);
        } else {
            current = new TreeItem(item.ID);
        }
    }
    TreeItem[] treeItems = result.Values.ToArray();
