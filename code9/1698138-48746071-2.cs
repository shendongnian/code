    using (DataClassesDataContext dataClassesDataContext = new DataClassesDataContext(cDbConnection.GetConnectionString()))
    {
        addresses.AddRange( from customer in dataClassesDataContext.Customers
            where (customer.Address.Latitude != ""
                   || customer.Address.Longitude != "")
            select new MyAppMaps.MapPoints() { Longitude = customer.Address.Longitude, Latitude = customer.Address.Latitude } );
    }
