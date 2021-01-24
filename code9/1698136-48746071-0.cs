    using (DataClassesDataContext dataClassesDataContext = new DataClassesDataContext(cDbConnection.GetConnectionString()))
    {
        var items = (from customer in dataClassesDataContext.Customers
            where (customer.Address.Latitude != ""
                   || customer.Address.Longitude != "")
            select new { Longitude = customer.Address.Longitude, Latitude = customer.Address.Latitude } ).ToList();
        if (items.Count > 0)
        {
            foreach (var item in query)
            {
                MyAppMaps.MapPoints address = new MyAppMaps.MapPoints();
                address.Lat = item.Latitude;
                address.Long = item.Longitude;
                addresses.Add(address);
            }
        }
    }
