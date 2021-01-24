    var results = context.Cars
                         .GroupBy(c => new { c.Make, c.Model })
                         .Select(g => new
                         {
                             Make = g.Key.Make,
                             Model = g.Key.Model,
                             IDs = g.Select(c => c.ID)
                         });
