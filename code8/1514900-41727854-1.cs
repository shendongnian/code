    var eventId = 123;
    return
        from conn in dataContext.Connections
        join cfg in dataContext.Configurations on conn.ConfigID equals cfg.ConfigID
        join u in dataContext.Users on cfg.UserID equals u.UserID
        where conn.Successful && u.AccountEventID == eventId
        group 1 by conn.CreatedDate.Date into g
        select new ConnectionItem
        {
            CreatedDate = g.Key,
            NumberOfConnections = g.Count(),
        };
