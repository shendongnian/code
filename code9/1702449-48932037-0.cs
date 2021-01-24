    private static void AddDescendants(IReadOnlyCollection<Item> items, TreeNode<Item> node)
    {
        var children = node.AddChildren(items.Where(i => i.Parent == node.Value.Child).ToArray());
        foreach (var child in children)
        {
            AddDescendants(items, child);
        }
    }
