    var result = db.Items
        .Select(item => new ItemsList()
        {
            Id = item.Id,
            ...
        })
        .AsEnumerable()       // bring your items to local memory
        .Select(item => GetCentralGeoCoordinate(...);
