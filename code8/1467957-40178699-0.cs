    List<Dictionary<string, string>> data = new List<Dictionary<string, string>>
    {
        new Dictionary<string, string>
        {
            ["Category"] = "99",
            ["Role"] = "11",
            ["Level"] = "22",
            ["BillaleDays"] = "33",
        },
        new Dictionary<string, string>
        {
            ["Category"] = "55",
            ["Role"] = "66",
            ["Level"] = "77",
            ["BillaleDays"] = "88",
        }
    };
    var result = data.SelectMany(item => item)
        .GroupBy(item => item.Key)
        .ToDictionary(key => key.Key, value => value.Select(i => i.Value).ToList());
    // Result:
    //     Category : (99,55)
    //     Role : (11,66)
    //     Level : (22,77)
    //     BillableDays : (33,88)
