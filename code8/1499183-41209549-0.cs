    using (DatabaseEntities entities = new DatabaseEntities())
    {
        //Gets a list of all customers, sorted by ticket date
        List<Table1> customers = entities.Table2.OrderByDescending(x => x.TicketDate).Select(x => x.Table1).Distinct().ToList();
    }
