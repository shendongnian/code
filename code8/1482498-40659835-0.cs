    var FirstLink = FirstLink
        .Concat(SecondLink)
        .GroupBy(e1 => e1.TableId)
        // Don't take the first item, but create a new one with the items you need
        .Select(e2 => new LinkedTable
            {
                TableId = e2.Key,
                TableName = e2.First().TableName,
                innerLinks = e2.SelectMany(x => x.innerLinks)
            })
        .ToList();
