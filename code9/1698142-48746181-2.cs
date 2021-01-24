    var addresses = dataClassesDataContext.Customers.
        .Select(c => c.Address)
        .Where(a => a.Latitude != "" || a.Longitude != "")
        .Select(a => new new MyAppMaps.MapPoints {
            Lat = a.Latitude, Long = a.Longitude
        }).ToList();
