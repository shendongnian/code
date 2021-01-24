    db.Hotels.Select(h => new HotelViewModel
             {
                 Name = h.Name,
                 City = h.City.City_Name,
                 Country = h.City.Country.Country_Name,
             }).ToList();
