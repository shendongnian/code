        var result=context.TimeEntries.GroupBy(m=>new {m.Name,m.Phase})
    .Select(m=>new {
    Name=m.Key.Name,
    Phase=m.Key.Phase,
    TimeWorked=m.Sum(o=>o.TimeWorked)
    
    });
