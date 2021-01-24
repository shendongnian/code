    var result = geocode1.Zip(geocode2, (c1, c2) => new ModelName
             {
               Address = c1.Address,
               City = c1.City,
               Zip = c1.Zip
               Street. c1.Street,
               Latitute = c2.Latitude
               Longitude = c2.Longitude,
               Status = c2.Status,
               Country = c2.Country
             }).ToList(); 
