    public IEnumerable<Item> BuildTree( IEnumerable<Item> source )
    {
        // build the children list for each item
        foreach ( var item in source )
        {
            item.Children = source.Where( i => i.ParentId == i.Id ).Tolist();
        }
        // return only the root parents
        return source.Where( i => i.ParentId == 0 ).ToList();
    }
