    var ticket = new Ticket
    {
        RequestBy = !string.IsNullOrEmpty(viewModel.RequestBy) ? viewModel.RequestBy : User.Identity.GetUserId(),
        PriorityId = viewModel.PriorityId != 0 ? viewModel.PriorityId : (int)PriorityLevel.Medium,
    };
    
    bool priorityLoaded = _context.Priority.Local.Any(e => e.Id == ticket.PriorityId);
    bool userLoaded = _context.ApplicationUser.Local.Any(e => e.Id == ticket.RequestBy);
    
    _context.Ticket.Add(ticket);
