    var model = Entities
                .Include(x => x.TicketUrgency)
                .GroupBy(x => new{ x.UrgencyId, x.TicketUrgency.Name })
                .Select(g => new {
                    id = g.Key.UrgencyId,
                    count = g.Count(),
                    name = g.Key.Name 
                });
