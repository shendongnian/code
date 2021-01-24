    (from t in TrnExpenses 
    group t by new { t.CreateOn.Value.Date, t.Note } into g
    orderby g.Key.Date descending
    select new{
        CreatedOn = g.Key.Date,
        Note = g.Key.Note,
        Count = g.Count()
    }).ToList()
