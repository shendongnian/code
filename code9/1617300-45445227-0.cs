    Entities.Include(e => e.Tickets)
                   .GroupBy(t => t.Id)
                   .Select(g => new {
                       id = g.Key,
                       name = g.FirstOrDefault().Name,
                       count = g.FirstOrDefault().Tickets.Count()
                   }); 
