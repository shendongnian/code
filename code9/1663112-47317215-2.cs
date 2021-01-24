    .Select(g => new SummaryDto {
        Name = g.Key.Name
    ,   GenericName = g.Key.GenericName
    ,   TotalCount = g.Sum(x => x.Count)
    ,   DataByYear = g.ToDictionary(i => i.Year, i => i.Count)
    }).AsQueryable();
