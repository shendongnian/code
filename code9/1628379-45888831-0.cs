    var results = DbContext.Orders
                           .Where(i => i.Id == Id)
                           .GroupBy(row => row.Status ?? 0)
                           .Select(g => new Stats()
                           {
                               Status = (Status)g.Key, //change it like that if it's the enum type
                               Count = g.Count()
                           }).ToList();
