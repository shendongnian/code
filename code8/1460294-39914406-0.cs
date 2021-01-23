    var result = (from price in inventoryDb.Pricing.AsNoTracking()               
                  where price.Quantity > 0m
                  from dup in Enumerable.Repeat(0,price.Quantity)
                  select new
                  {
                     TagNo = price.TagNo,
                     SellingRate = price.SellingRate,          
                  }).ToList();
