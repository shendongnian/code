    var eventId = 123;
    return dataContext.Connections.Join(dataContext.Configurations,
            conn => conn.ConfigID,
            cfg => cfg.ConfigID,
            (conn, cfg) => new { conn, cfg })
        .Join(dataContext.Users,
            x => x.cfg.UserID,
            u => u.UserID,
            (x, u) => new { x.conn, u })
        .Where(x => x.conn.Successful && x.u.AccountEventID == eventId)
        .GroupBy(x => x.conn.CreatedDate.Date)
        .Select(g => new ConnectionItem
        {
            CreatedDate = g.Key,
            NumberOfConnections = g.Count(),
        });
