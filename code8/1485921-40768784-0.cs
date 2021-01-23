    ICollection<MyObject> Method(ICollection<MyObject> coll)
    {
        var lookup = new Dictionary<int, MyObject>();
        foreach (var item in coll)
        {
             lookup.Add(item.id, item);
        }
        foreach (var item in coll)
        {
             item.parentObj = lookup[item.parentId];
        }
        return coll;
    }
