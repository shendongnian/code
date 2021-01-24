    using System.IO;
    
    List<RootObject> objects = File.ReadAllLines("example.json")
        .Select(line => JsonConvert.DeserializeObject<RootObject>(line))
        .ToList();
