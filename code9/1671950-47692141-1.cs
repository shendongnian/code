    var objs = new[]
    {
        new {Id = 1, Name = "Core"},
        new {Id = 2, Name = "Moderate"},
        new {Id = 3, Name = "Remote"},
    };
    var json1 = JsonConvert.SerializeObject(objs);
    Console.WriteLine(json1);
    
    var dict = objs.ToDictionary(k => k.Id.ToString(), v => v.Name);
    
    var json2 = JsonConvert.SerializeObject(dict);
    Console.WriteLine(json2);
