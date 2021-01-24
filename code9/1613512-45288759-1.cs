    public async Task<List<SomeModel>> SomeMethod(DateTime? fromDate, DateTime? toDate)
    {
      return _db.Payments
        .Where(p =>
            DateTime.Compare(p.TradeDate, (DateTime)fromDate) >= 0 &&
            DateTime.Compare(p.TradeDate, (DateTime)toDate) <= 0))
        .GroupBy(p=>p.ClientId)
        .Select(g=>new SomeModel { 
          UserName = g.First().Client.UserName,
          Bcf = g.Sum(p=>p.Bcf),
          Ecn = g.Sum(p=>p.Ecn),
          Ecbt = g.Sum(p=>p.Ecbt),
          OpenGl = g.Sum(p=>p.OpenGl),
          JeyK = g.Sum(p=>p.JeyK)
        })
        .ToListAsync();
    }
