    var List<List<Item>> groups = new List<List<Item>>()
    var currentGroup = new List<Item> { items.First() };
    int i = 0;
    foreach(var item in items.Skip(1))
    {
        if(currentGroup.First().Name != item.Name)
        {
            groups.Add(currentGroup);
            currentGroup = new List<Item> { item };
        }
        else
        {
            currentGroup.Add(item);
            if(i == items.Count - 2) 
                groups.Add(currentGroup);
        }
        i++;
    }
