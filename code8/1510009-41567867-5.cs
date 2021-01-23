    List<string[]> list = new List<string[]>();
    list.Add(new string[] { "Value","value" });
    list.Add(new string[] { "b2", "b22" });
    var ee = JsonConvert.SerializeObject(list);
    Console.WriteLine(ee);
    List<string[]> ll = JsonConvert.DeserializeObject<List<string[]>>(ee);
    foreach (var Valus in ll)
    {
        foreach (var val in Valus)
        {
             Console.WriteLine(val);
        }
    }
