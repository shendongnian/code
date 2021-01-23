    var result = (from price in inventoryDb.Pricing.AsNoTracking()
                                                   .Where(p => p.Quantity > 0m)
                                                   .AsEnumerable()            
                  from dup in Enumerable.Repeat(0,price.Quantity)
                  select new
                  {
                     TagNo = price.TagNo,
                     SellingRate = price.SellingRate,          
                  }).ToList();
