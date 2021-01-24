    Dictionary<int, string> data = tabledata
      .ToDictionary(p => p.id, p => p.Name);
    ...
    string name123 = data[123]; // let's have a value that corresponds to id = 123
    if (data.ContainsKey(789)) {
      // do we have id = 789? 
    }
    if (data.TryGetValue(456, out var name456)) { // C# 7.0 Syntax
      // If we have id = 456, return corresponding value into name456
    }
