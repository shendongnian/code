    var obj = dbContext.InstitutionEnquiry
            // WHERE CITY = 'AHMEDABAD'
            .Where(w => w.City == "AHMEDABAD")
            // GROUP BY addressline3, city
            .GroupBy(g => new {g.AddressLine3, g.City})
            // SELECT addressline3, city, COUNT(*) as 'InstitutionNumber'
            .Select(c => new {c.Key.AddressLine3, c.Key.City, InstitutionNumber = c.Count()})
            // ORDER BY city
            .OrderBy(o=> o.City)
            .ToList();
