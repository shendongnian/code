    var finalData = data
        .GroupBy(d=>d.DueDate)
        .Select(g=>
            new {
                DueDate = g.Key, 
                Values = g.Select(d2=>new{d2.Desc, d2.Amount})})
