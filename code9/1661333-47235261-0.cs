    public IQueryable<ItemDTO> GetList()
    {
        var sourceItems = db.Items.Include(x => x.Locations).ToList(); 
        var items = sourceItems.Select(item => new ItemDTO()
            {
                Id = item.Id,
                Title = item.Title
                Coordinates = GetCentralGeoCoordinate(
                              item.Locations
                                  .Select(itemLocation => new GeoCoordinate()
                                   {
                                      Latitude = Double.Parse(itemLocation.cX, CultureInfo.InvariantCulture),
                                      Longitude = Double.Parse(itemLocation.cY, CultureInfo.InvariantCulture)
                                   })
                              });       
    
        return items.AsQueryable();
    }
