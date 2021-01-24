    string item = string.Empty;
    List<string> keyss = new List<string>();
    while (!string.IsNullOrWhiteSpace(item = Console.ReadLine()))
    {                 
        keyss.Add(item);
    } 
    foreach (var itm in keyss)
    {
        Console.WriteLine(itm);
    }
