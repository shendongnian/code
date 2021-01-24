    var values = new string [] { "1", "1", "2", "2", "2", "1", "3", "2", "1" };
    var groups = values.GroupBy(i => i).Select(i => new { Number = i.Key, Count = i.Count() });
    foreach(var item in groups)
    {
     if(item.Count == 4)
     {
        Console.WriteLine(item.Number);
     }
    }
