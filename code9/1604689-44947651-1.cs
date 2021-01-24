    public async Task<ActionResult> NewTickets()
    {
        // Show tickets for all divisions a agent is in
    
        var user = "abcdefg";
        var company = "company1";
    
        var tickets = await (from a in db2.Ticket
            join c in db2.Division on a.DivisionId equals c.DivisionId
            join dp in db2.DivisionParticipator on c.DivisionId equals dp.DivisionId
            where c.CompanyId == company.CompanyId && a.Status == "New" && dp.ApplicationUserId == user.Id
            select new Ticket
            {
                Id = a.Id,
                DivisionId = a.DivisionId,
                Name = a.Name,
                TicketDate = a.TicketDate,
                NewPosts = a.NewPosts,
                Status = a.Status,
                Type = a.Type
             })
             .ToListAsync();
    
        return PartialView(tickets);
    }
