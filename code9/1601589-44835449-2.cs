    var finalData = data
            .GroupBy(d=>d.DueDate)
            .Select(g=>
                new {
                     DueDate = g.Key, 
                     Values = g.Select(d2=>d2)
                    })
            .ToDictionary(o=>o.DueDate, o=>o.Values)
