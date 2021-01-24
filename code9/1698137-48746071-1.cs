    using (DataClassesDataContext dataClassesDataContext = new DataClassesDataContext(cDbConnection.GetConnectionString()))
    {
        var items = (from customer in dataClassesDataContext.Customers
            where (customer.Address.Latitude != ""
                   || customer.Address.Longitude != "")
            select new { Longitude = customer.Address.Longitude, Latitude = customer.Address.Latitude } ).ToList();
        if (items.Count > 0)
        {
            addresses.AddRange(
                 items.Select( address => new MyAppMaps.MapPoints(){ 
                      Lat = address.Latitude,
                      Lon = address.Longitude 
                 } ) );
        }
    }
