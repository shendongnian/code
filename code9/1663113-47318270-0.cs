    var q = data.GroupBy(x => new {
        x.Med.Name,
        x.Med.GenericName,
    }).ToList().Select(g => {
        var gg = g.GroupBy(d => d.ProcessDate.Year).ToDictionary(d => d.Key, d => d.Count());
        return new SummaryDto {
            Name = g.Key.Name,
            GenericName = g.Key.GenericName,
            Data2012 = gg.GetValueOrDefault(2012),
            Data2013 = gg.GetValueOrDefault(2013),
            Data2014 = gg.GetValueOrDefault(2014),
            Data2015 = gg.GetValueOrDefault(2015),
            Data2016 = gg.GetValueOrDefault(2016),
            Data2017 = gg.GetValueOrDefault(2017),
            TotalCount = g.Count(),
        };
    }).AsQueryable();
