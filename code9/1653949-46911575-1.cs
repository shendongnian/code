    var partialResult = (from i in dc.Ses
                          where i.id == id
                          select
                            new
                            {
                                id = i.id,
                                FullName = i.FullName,
                                RawType = i.Type
                            });
    var finalResult = partialResult.AsEnumerable().Select(entry => new {
        ...
        Type = entry.RawType.HasValue ? arr1[entry.RawType] : null
    });
