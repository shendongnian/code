    var result3 = result2.Select(item => new
    {
        Name = item.Name,
        LowestId = item.AllIds.Orderby(id => id).First(),
        Places = item.Places,
        Locations = item.Locations,
        OneAndOnlyGroupId = item.GroupId.First(),
    };
