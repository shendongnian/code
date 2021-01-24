    var resultSet=TrnExpenses.GroupBy(s=>new 
    {
    	s.CreateOn.Value.Date, s.Note
    })
    .OrderByDescending(s=>s.Key.Date)
    .Select(s=>new
    {
    	s.Key.Date,
        s.Key.Note,
        Count = s.Count()
    });
