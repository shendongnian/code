    private IEnumerable<Item> Sort(IQueryable<Item> items)
    {
        return items.AsEnumerable().OrderBy(i => i.Type)
                                    .ThenBy(i => Item.MyDic.Keys.Any(key => key == i.Type)
                                                ? Item.MyDic[i.Type].Item2: -1);
    }
