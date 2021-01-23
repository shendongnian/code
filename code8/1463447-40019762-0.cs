    conn.SCOT_DADOS.GroupBy(item => item.User)
               .Select(grp => grp.OrderByDescending(i => t.Date).First())
               .Select(item => new {
                   Name = svc.GetUserName(item.User),
                   Value = item.Value,
                   Date = item.Date.ToString("dd/MM/yyyy HH:mm:ss")
               }).ToList();
