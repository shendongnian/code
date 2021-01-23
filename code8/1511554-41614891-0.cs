    var Cities = (from city in db.Cities
               select new  // Creating anonymous type to fill List of Houses 
               {
                  CityId = city.CityId,
                  Name   = city.Name, 
                  Houses = city.Houses.Select( new
                                    {
                                        HouseId = h.HouseId,
                                        Address = h.Address,
                                        Residents = h.Residents.ToList()
                                    }).ToList()
                                    .Select( h => new Houses
                                    {
                                        HouseId = h.HouseId,
                                        Address = h.Address,
                                        Residents = h.Houses
                                    }).ToList()
               })
               .ToList()
               .Select( c=> new Cities
               {
                  CityId = c.CityId
                  Name   = c.Name, 
                  Houses = c.Houses
               }).ToList()
