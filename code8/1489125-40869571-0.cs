    var statistics = 
        from b in db.Bookings
        group b by b.Customer.zipcode into g
        select new
        { 
            Zipcode = g.Key,
            NumberOfBookings = g.Count(),
            NumberOfEquipments = g.SelectMany(b => b.Equipments).Count(),
        };
