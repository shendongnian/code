    var summaries = records
        .Select(ConvertGenericRecord)
        .GroupBy(x => x.GroupName)
        .Select(x => new {
            GroupName = x.Key,
            Total1 = x.Sum(y => y.ConvertedCol1),
            Total2 = x.Sum(y => y.ConvertedCol2),
            Total3 = x.Sum(y => y.ConvertedCol3),
            Count = x.Count()
        }).ToList();
