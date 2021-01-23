    var input = "12";
    
    var mappings = new Dictionary<string, string[]>();
    mappings.Add("1", new string[] { "A", "J", "S" });
    mappings.Add("2", new string[] { "B", "K", "T" });
                
    var result = input.Select(c => mappings[c.ToString()]).CartesianProduct();
    
    foreach (var item in result)
    {
        Console.WriteLine(string.Join("", item.ToArray()));
    }
