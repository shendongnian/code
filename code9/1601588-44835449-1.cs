    var finalData = data
        .GroupBy(d=>d.DueDate)
        .Select(g=>
            new {
                DueDate = g.Key, 
                Values = g.Select(d2=>new{d2.Desc, d2.Amount})})
    The Final Structure would be 
    finalDate = [
        {
            DueDate:'06-29-1015', 
            Values:[{Desc:"ABC", Amount:100}, {Desc:"DEF", Amount:200}]
        },
        {...}
    ]
