    string[] source = ...
    
    var data = source
      .Select(line => line.Split('='))
      .Select(items => new {           // Let's have classes
          Col = int.Parse(items[0].Substring(3)),
          Name = items[1],
          Value = items[2], })
      .OrderBy(item => item.Col);     // ... which are easy to handle (e.g. sort) 
