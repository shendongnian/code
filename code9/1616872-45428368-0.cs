    var ticketTypes = _context
                    .TicketType
                    .Where(w => w.Deleted == false)
                    .Select(s => new {
                                                        id = s.Id,
                                                        Name = s.Name
                        }).OrderBy(o=>o.Name).ToList();
    
    ViewBag.ticketTypeList = new SelectList(ticketTypes, "id", "Name");
