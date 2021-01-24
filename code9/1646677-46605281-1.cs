    var find = str.GroupBy(t => t)
    .Select(y => new { character = y.Key, Count = y.Count() })
    .Where(a => a.Count < 2).FirstOrDefault()?.character;
      
      Console.WriteLine(find);    
      Console.ReadLine();
