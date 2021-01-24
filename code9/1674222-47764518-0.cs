    var d = new Dictionary<string, int>();
    d.Add("Key2",2);
    d.Add("Key1",1);
    //Sort by key
    foreach (var k1 in d.OrderBy(a => a.Key))
        Console.Writeline(k1.Value);
    //Sort by value
    foreach (var k2 in d.OrderBy(a => a.Value))
        Console.Writeline(k2.Value);
