    var rawData = new List<(string group, List<string> species)>
    {
        ("Cat", new List<string> { "Cheetah", "Lion" }),
        //...
    };
    var result = rawData.SelectMany(item => item.species.Distinct()
                                                        .Select(s => (key = s, value = item.group)))
                        .ToDictionary(k => k.key, v => v.value);
