    .Select(grouping => new 
    { 
        Tag = grouping.Key,
        Amount = grouping.Count(),
        Items = grouping.Select(item => item.Item)
    })
 
