<!-- -->
    var dictionary = ReadAllLines()
        .GroupBy(line => line.Zoo)
        .ToDictionary(zoo => zoo.Key,
                      zoo => zoo.ToDictionary(animal => animal.Animal,
                                              animal => new { animal.Mn, animal.Tu }));
    
    var sb = new StringBuilder();
    using (var sw = new System.IO.StringWriter(sb))
    {
        new Newtonsoft.Json.JsonSerializer().Serialize(sw, dictionary);
    }
    Console.WriteLine(sb.ToString());
