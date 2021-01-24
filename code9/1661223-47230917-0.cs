    public IQueryable<GeoCoordinate> GetList()
    {
        // this ToList fetches the data from the db. 
        // now you don't have to worry about convert inside EF
        var sourceItems = db.Items.Include(x => x.Locations).ToList(); 
        var items = sourceItems.Select(item => new ItemDTO()
            {
                Id = item.Id,
                Title = item.Title
                Coordinates = item.Locations
                    .Select(LocationsItem => new GeoCoordinate()
                    {
                        Latitude = Convert.ToDouble(item.Locations.FirstOrDefault().cX),
                        Longitude = Convert.ToDouble(item.Locations.FirstOrDefault().cY)
                    })
            })
            .AsEnumerable()
            .Select(fetchedItem => GetCentralGeoCoordinate(fetchedItem.Coordinates));
        return items.AsQueryable();
    }
