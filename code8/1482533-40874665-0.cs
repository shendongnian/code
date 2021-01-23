    var parentGroups = dbContext.Items.ToLookup(x => x.ParentId, x => new Projection
    {
        Id = x.Id,
        PropertyA = x.PropertyA
    });
    // fix up children
    foreach (var item in parentGroups.SelectMany(x => x))
    {
        item.Children = parentGroups[item.Id].ToList();
    }
