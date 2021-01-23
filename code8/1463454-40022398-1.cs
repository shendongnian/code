    var result = conn.SCOT_DADOS
        .Where(r => !conn.SCOT_DADOS.Any(r2 => r2.USER == r.USER && r2.Date > r.Date))
        // end of Db Query 
        .AsEnumerable()
        .Select(r => new
        {
            Name = svc.GetUserName(r.User),
            Value = r.Value,
            Date = r.Date.ToString("dd/MM/yyyy HH:mm:ss")
        }).ToList(); 
