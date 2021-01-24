    var result=  Entities
                .Include(h => h.TicketSubCategories)
                .ThenInclude(s => s.Tickets)
                .GroupBy(s => new{s.Id, s.Name})
                .Select(t => new Cata {
                                Name = t.Key.Name,
                                Children= t.SelectMany(e=>e.TicketSubCategories.Select(ts=>ts.Tickets)).Count()
                             };
