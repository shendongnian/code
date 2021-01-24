     var model = Entities
                    .Include(x => x.TicketUrgency)
                    .GroupBy(x => new {UrgencyId =  x.UrgencyId ,
                              Name = x.TicketUrgency.Name})
                    .Select(x=> new { UrgencyId = x.Key.UrgencyId,
                                      Name = x.Key.Name,
                                      Count = x.Count()});
              
