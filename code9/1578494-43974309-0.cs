    var ids = custFinal.Select(c => c.ID).ToArray();
    var andlist = db.Service.Where(serv => ids.Contains(serv.CustID)).Select(c =>
       new JoinObj {
           Name = c.Name,
           ServiceID = c.CustID
       };
