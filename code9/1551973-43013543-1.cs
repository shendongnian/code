    var nestedDictionary = new List<Dictionary<string, Dictionary<string, object>>>
    {
        new Dictionary<string, Dictionary<string, object>>
        {
            {
                "Foo",
                new Dictionary<string, object>
                {
                    {"Bar", "I'm a string"},
                    {"status", 310}
                }
            },
            {
                "John",
                new Dictionary<string, object>
                {
                    {"Bar", "I'm a string"},
                    {"status", 310}
                }
            }
        },
        ... next top level dictionary here
    };
    var showList = nestedDictionary
        .Where(dic => dic.ContainsKey("John") 
            && dic["John"].Any(kvp => kvp.Key == "status" && kvp.Value.Equals(310)))
        .ToList();
