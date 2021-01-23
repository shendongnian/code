    var initialData = new List<Dictionary<string, List<string>>>
    {
        new Dictionary<string, List<string>>
        {
            { "Header1", new List<string> {"25%", "1.4%", "0.93%" } },
            { "Header2", new List<string> {"51%", "42%", "16%" } },
            { "Header3", new List<string> {"8%", "99%", "11.37%" } }
        },
    };
    var result = new
    {
        data = initialData.First()
                .Select(kvp => kvp.Value.Select((v, i) => 
                               new { Key = kvp.Key, Value = v, Index = i }))
                .SelectMany(a => a)
                .GroupBy(a => a.Index)
                .Select(g => g.ToDictionary(a => a.Key, a => a.Value))
    };
    string json = JsonConvert.SerializeObject(result, Formatting.Indented);
    Console.WriteLine(json);
