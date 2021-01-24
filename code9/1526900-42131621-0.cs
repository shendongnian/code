    var res = await (from c in dbCtx.Customers
                     where c.CustomerMarket = "GB"
                     let homeCount = c.Products.Where(p => p.Category = "HomeAppliance").Count()
                     let furnCount = c.Products.Where(p => p.Category = "Furnishing").Count()
                     orderby c.CustomerID descending
                     select new {
                       CustomerID = c.CustomerID,
                       CustomerName = c.CustomerName,
                       ApplianceCount = homeCount,
                       FurnishingCount = furnCount
                     }).ToListAsync();
