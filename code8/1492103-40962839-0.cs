    var categories = db.Items.GroupBy(p => p.Category).
        Select(group =>
            new
            {
                name = group.Key,
                data = group.GroupBy(g => g.City),
                total = group.Count()
            });
