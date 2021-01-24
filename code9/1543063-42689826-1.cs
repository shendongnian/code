    var result = (from t in TrnExpense 
    group t by new { t.CreatedOn.Date, t.Note } into g
    orderby g.Key.Date descending
    select new{
        CreatedOn = g.Key.Date,
        Note = g.Key.Note,
        Count = g.Count()
    }).ToList();
