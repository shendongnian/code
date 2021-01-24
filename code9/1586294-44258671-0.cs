    var map1 = cfg.CreateMap<DateTime?, DateTime?>();
    map1.ProjectUsing(i => DbFunctions.AddHours(i, offset.Hours));
    map1.ConvertUsing(i => i?.AddHours(offset.Hours));
    
    var map2 = cfg.CreateMap<DateTime, DateTime>();
    map2.ProjectUsing(i => DbFunctions.AddHours(i, offset.Hours).Value);
    map2.ConvertUsing(i => i.AddHours(offset.Hours));
