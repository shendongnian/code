    int groupID = -1;
    var result = items.Select((item, index) =>
    {
        if (index == 0 || items[index - 1].Name != item.Name)
            ++groupID;
        return new { group = groupID, item = item };
    }).GroupBy(item => item.group).Select(group =>
    {
        Item item = new Item();
        var first = group.First().item;
        var last = group.Last().item;
        item.Name = first.Name;
        item.Start = first.Start;
        item.End = last.End;
        item.Orders = group.SelectMany(g => g.item.Orders).Distinct().ToList();
        return item;
    });
