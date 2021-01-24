    var colorContract = colourEntryList.Select(x => new ColorContract()
    {
        Id = x.Id.ToDisplayString(),
        Name = x.Name,
        Properties = x.Properties
            .Cast<DictionaryEntry>()
            .Select(kv => new PropertiesContract{ Key = kv.Key, Value = kv.Value })
            .ToList()
    }
    return colorContract;
