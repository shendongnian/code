    public static IList<AttributeItemNode> SortAttributeItems(IList<AttributeItem> list)
    {
        var childrenMap = list.ToLookup(e => e.ParentSortID ?? int.MinValue);
        return childrenMap[int.MinValue].OrderBy(item => item.SortID)
            .Expand(parent => childrenMap[parent.SortID].OrderBy(item => item.SortID),
                (item, depth) => new AttributeItemNode(item, depth))
            .ToList();
    }
