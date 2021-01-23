    class FlattenTree
    {
      // map each item to its children
      ILookup<Category, Category> mapping;
      public FlattenTree(IEnumerable<Category> list)
      {
        var itemLookup = list.ToDictionary(item => item.ID);
        mapping = list.Where(i => i.ParentCategoryID.HasValue)
                      .ToLookup(i => itemLookup[i.ParentCategoryID.Value]);
      }
      IEnumerable<Item> YieldItemAndChildren(Item node)
      {
        yield return node;
        foreach (var child in mapping[node].OrderBy(i => i.CategoryName))
            foreach (var grandchild in YieldItemAndChildren(child))
                yield return grandchild;
      }
      public IEnumerable<Category> Sort()
      {
        return from grouping in mapping
               let item = grouping.Key
               where item.ParentCategoryID == null
               orderby item.CategoryName
               from child in YieldItemAndChildren(item)
               select child;
      }
    }
