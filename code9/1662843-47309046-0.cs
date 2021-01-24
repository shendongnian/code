    var ticketGroups = tickets.OrderBy(x => x.created_time)
                                .GroupBy(x => new { x.owner, x.reffering });
    var tensecondTimespam = new TimeSpan(0, 0, 10);
    var results = new List<List<Ticket>>();
    var ticketTemps = new List<Ticket>();
    
    foreach (var ticketGroup in ticketGroups)
    {
        foreach (var ticket in ticketGroup)
        {
            var currentTicket = ticketTemps.LastOrDefault();
            var isWithinTimeRange = currentTicket == null
                                    || ticket.created_time.Value - currentTicket.created_time.Value <= tensecondTimespam;
    
            if (!isWithinTimeRange)
            {
                results.Add(ticketTemps);
                ticketTemps = new List<Ticket>();
            }
            ticketTemps.Add(ticket);
        }
        if (ticketTemps.Any())
        {
            results.Add(ticketTemps);
            ticketTemps = new List<Ticket>();
        }
    }
