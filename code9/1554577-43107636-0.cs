    var itemsData = _context.Items.ToList();
    foreach (var item in itemsData)
    {
        _Response.Items.Add(new Models.Items
        {
            Name = item .Name,
            ....
            Created = (DateTime)item.Created,
            Updated = (DateTime)item.Updated
        });
    }
