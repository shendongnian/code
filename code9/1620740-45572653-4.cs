    var result=  Entities
                .Include(h => h.TicketSubCategories)
                .ThenInclude(s => s.Tickets)
                .Select(t => new Cata {
                                Name = t.Name,
                                Children= t.TicketSubCategories
                                           .Select(ts=>new SubCat{
                                                         Name=ts.Name,
                                                         Count=ts.Tickets.Count()})
                             };
