    List<Item> RemoveNodes(List<Item> tree)
    {
        var ret = tree.Where(item => !item.IsLastItem);
        foreach (Item item in ret)
        {
            item.SubItems = RemoveNodes(item.SubItems);
        }
        return ret;
    }
