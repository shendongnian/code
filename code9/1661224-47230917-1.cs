    public IQueryable<GeoCoordinate> GetList()
    {
        // this ToList fetches the data from the db. 
        // now you don't have to worry about convert inside EF
        var sourceItems = db.Items.Include(x => x.Locations).ToList(); 
        // Select updated to answer part 2 (I believe).
        var items = sourceItems.Select(item => new ItemDTO()
            {
                Id = item.Id,
                Title = item.Title
                Coordinates = item.Locations
                    .Select(itemLocation => new GeoCoordinate()
                    {
                        Latitude = Convert.ToDouble(itemLocation.cX),
                        Longitude = Convert.ToDouble(itemLocation.cY)
                    })
            })
            .AsEnumerable()
            .Select(fetchedItem => GetCentralGeoCoordinate(fetchedItem.Coordinates));
        return items.AsQueryable();
    }
