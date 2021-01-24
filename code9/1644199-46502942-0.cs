    var result = yourEnumerable
        .GroupBy(s => new {s.SectionID, s.SectionName, s.TagID, s.TagName})
        .Select(x => new
        {
            x.Key.SectionID,
            x.Key.SectionName,
            x.Key.TagID,
            x.Key.TagName,
            SubSection = x.Count() == 1 ? null : x.Select(y => new
            {
                y.SubSectionID,
                y.SubSectionName
            }).ToArray()
        });
        
