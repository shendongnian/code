    Dictionary<string, List<string>> dict = obj["values"]
        .Select(jo => jo.SelectToken("categories.values")
                        .Select(t => new
                        {
                            Category = (string)t,
                            Name = (string)jo["Name"]
                        }))
        .SelectMany(a => a)
        .GroupBy(a => a.Category)
        .ToDictionary(g => g.Key, g => g.Select(a => a.Name).ToList());
