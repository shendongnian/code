    var items = db.Items
    select (item => new ItemsList()
    {
        Id = item.Id,
        Title = item.Title,
        Coordinates = item.OtherCollection
            .Select(otherCollectionItem => new Coordinate()
            {
                Cx = otherCollectionItem.Cx,
                Cy = otherCollectionItem.Cy,
            })
            .ToList(),
    }
    .AsEnumerable()
    .Select(fetchedItem => GetCentralGeoCoordinate(fetchedItem.Coordinate));
