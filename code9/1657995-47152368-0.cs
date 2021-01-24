    var data = dpToAdd.Select(x => new DataPointHelper 
    {
        DateTime = x.DateTime,
        Value = x.Value
    }).ToList();
    context.DataPointHelpers.AddRange(data);
    context.SaveChanges();
    
    var toInsert = (from x in context.DataPointHelpers
    			    join y in context.DataPoints on x.DateTime equals y.DateTime into subs
    			    from sub in subs.DefaultIfEmpty()
    			    where sub == null
    			    select x.DateTime).ToList();
    
    var toInsertData = dpToAdd.Where(x => toInsert.Contains(x.DateTime)).ToList();
    context.DataPoints.AddRange(toInsertData);
    context.SaveChanges();
