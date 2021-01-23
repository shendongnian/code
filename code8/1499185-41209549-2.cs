    using (DatabaseEntities entities = new DatabaseEntities())
    {
        //Gets a list of all customers, sorted by ticket date
        List<Table1> customers = entities.Table1
        .OrderByDescending(x => x.Table2.Select(y => y.TicketDate).OrderByDescending(y => y.TicketDate)
        .FirstOrDefault().TicketDate)
        .ToList();
    }
