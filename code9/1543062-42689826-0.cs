    var result = (from t in TrnExpense 
    group t by new { t.CreatedOn, t.Note } into g
    orderby g.Key.CreatedOn descending
    select new{
        CreatedOn = g.Key.CreatedOn,
        Note = g.Key.Note,
        Count = g.Count()
    }).ToList();
