    var dictionary = elements
      .SelectMany(p => p.Properties.Keys)
      .Distinct()
      .Select((key, index) => new {
         key = key,
         value = index + 1, 
       })
      .ToDictionary(item => item.key, item => item.value);
