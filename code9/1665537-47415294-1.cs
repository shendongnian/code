    var fakeItems = new Dictionary<int, Model>();
    var unpaged = MyService.MyServiceMethod(MySearchModel);
    for (var i = 0; i < unpaged.Count; i++)
    {
        if (unpaged[i].IsFake)
            fakeItems.Add(i, unpaged);
    }
    var paged = unpaged.Where(x => !x.IsFake)
        .Skip((page - 1) * pageSize)
        .Take(pageSize - fakeItems.Count);
    foreach (var item in fakeItems){
    {
        paged.Insert(item.Key, item.Value);
    }
