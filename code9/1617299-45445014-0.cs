    var model = Entities
                .Include(x => x.TicketUrgency)
                .GroupBy(x => x.UrgencyId)
                .Select(g => new {
                    id = g.Key,
                    name = g.First().TicketUrgency.Name
                    count = g.Count(),
                });
