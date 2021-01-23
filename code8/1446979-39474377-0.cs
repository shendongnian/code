    private IEnumerable<TreeViewItem> Enumerate(ItemsControl itemsControl, ItemCollection items)
    {
        foreach (XmlElement element in items)
        {
            TreeViewItem item = itemsControl.ItemContainerGenerator.ContainerFromItem(element) as TreeViewItem;
            if (item != null) //When second call with <a>.Items, item is null
            {
                item.IsExpanded = true;
                item.UpdateLayout();
    
                yield return item;
            }
            //Enumerate is called again with <a>.Items 
            //Exception in second call, because item is null
            foreach (TreeViewItem i in Enumerate(item, item.Items))
            {
                yield return i;
            }
        }
    }
    
    private void tv_Loaded_1(object sender, RoutedEventArgs e)
    {
        var list = Enumerate(tv, tv.Items).ToList();
    }
