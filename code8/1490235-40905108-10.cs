    var result = File
      .ReadLines(SPFile)
      .AsParallel() // if you really want to use PLinq 
      .Select(line => {
         double order;
         bool has = double.TryParse(line.Substring(line.LastIndexOf(">") + 1), out order);
         return new {
           line = line,
           order = order,
           has = has   
         };
        })
      .OrderBy(item => item.has) // or OrderByDescending(item => item.has)
      .ThenBy(item => item.order)
      .Select(item => item.line)
      .ToList(); 
    
