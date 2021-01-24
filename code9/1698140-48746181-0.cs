    var addresses = dataClassesDataContext.Customers.
        .Select(c => c.Address)
        .Where(a => a.Latitude != "" || a.Longitude != "")
        .Select(c => new {
            a.Latitude
        ,   a.Longitude
        }).AsEnumerable()
        .Select(p => new MyAppMaps.MapPoints {
            Lat = p.Latitude, Long = p.Longitude
        }).ToList();
