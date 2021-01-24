    var partialResult = (from i in dc.Ses
                          where i.id == id
                          select
                            new
                            {
                                id = i.id,
                                FullName = i.FullName,
                                RawType = i.Type
                            }).ToList();
    var finalResult = partialResult.AsEnumerable().Select(entry => new {
        ...
        Type = RawType.HasValue ? arr1[RawType] : null
    });
