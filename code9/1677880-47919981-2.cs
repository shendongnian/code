      var list = new List<string>() {
        "a",
        "a 4",
        "b 1",
        "a 2",
        "a 11"
      };
      var result = list
        .Select(item => new {
           value = item,
           match = Regex.Match(item, @"^(?<name>.*?)\s*(?<number>[0-9]*)$"), 
         })
      .OrderBy(item => item.match.Groups["name"].Value)
      .ThenBy(item => item.match.Groups["number"].Value.Length)
      .ThenBy(item => item.match.Groups["number"].Value)
      .Select(item => item.value);
