    var groupedList = list.GroupBy(i => new
    {
        i.TicketID,
        i.Priority,
        i.Email
    }).Select(g => new Ticket()
    {
        TicketID = g.Key.TicketID,
        Email = g.Key.Email,
        Priority = g.Key.Priority,
        Files = g.SelectMany(x => x.Files).ToList()
    }).ToList();
