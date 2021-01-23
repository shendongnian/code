    from ot in dbContext.OrderTemplates
    join u in dbContext.Users on ot.UserId equals u.UserID
    join c in dbContext.Clients on u.ClientID equals c.ClientID
    group ot by new { ot.UserId, u.UserName, c.ClientName } into g
    select new 
    { 
        UserName = g.Key.UserName,
    	ClientName = g.Key.ClientName,
    	OrderCount = g.Count(),
    	TotalAmount = g.Sum(x=> x.TotalAmount)
    };
