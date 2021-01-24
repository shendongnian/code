    var result=  Entities
                .Include(h => h.TicketSubCategories)
                .ThenInclude(s => s.Tickets)
                .Select(t => new Cata {
                                Name = t.Name,
                                Children= t.TicketSubCategories.SelectMany(ts=>ts.Tickets).Count()
                             };
