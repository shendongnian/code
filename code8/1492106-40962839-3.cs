    var categories = db.Items.GroupBy(p => p.Category).Select(group =>
    new
    {
        Name = group.Key,
        Data = group.GroupBy(g => g.City),
        Total = group.Count()
    });
