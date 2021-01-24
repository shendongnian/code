         select new
         {
           businCatID = businCat.CatID,
           businCat = businCat.Category,
           companyName = v.CompanyName,
           description = v.Description,
           addressLine1 = a.AddressLine1,
           addressLine2 = a.AddressLine2,
           city = a.City,
           state = a.StateID,
           zip = a.Zip,
           phone = c.Phone,
           email = (c.Email == null ? "No E-mail Address Available" : c.Email),
           Hyperlink = (c.Website == null ? "No Website Available" : c.Website),
           geoLocation = geoMarket.GeoMarket,
           counDistrict = c.DistrictID}).OrderBy(m => m.businCat).ThenBy(n => n.companyName).ToList();
    
