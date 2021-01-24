      List<int> resultList = File
        .ReadLines(data)                      // you've got IEnumerable<string>
        .Select(line => line.Split())         // -/- IEnumerable<string[]>
        .Select(ietms => int.Parse(items[0])) // -/- IEnumerable<int> 
        .ToList();                            // finally, it's List<int> 
  
