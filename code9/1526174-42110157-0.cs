ctx.Tickets
    .Where(t => t.ClosedOn == null &&
       t.AssignedToTeamId == 1 &&
       (t.TicketPriorityId == 1 || t.TicketPriorityId == 2))    
    .Select(t => new
    {
        t.ServerId, t.SiteId,
        DetectorId = t.DetectorId - t.DetectorId % 10
    })
    .Select(x => new
    {
       x.ServerId, x.SiteId,
       DetectorId = ctx.Tickets
          .Where(t => t.SiteId != null && t.ClosedOn == null &&
              t.AssignedToTeamId == 1 &&
              (t.TicketPriorityId == 1 || t.TicketPriorityId == 2))
          .Any(t => t.Id == x.DetectorId) ? 
          (int?) null : x.DetectorId
    })
    .ToArray();
