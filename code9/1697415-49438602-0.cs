    var queryResult = MainEntities.Select(m => 
        new {
            MainEntity = m,
            m.SubEntities.Where(s => !s.DoNotLoad)
        })
        .ToList();
    var finalList = queryResult.Select(q => q.MainEntity).ToList();
