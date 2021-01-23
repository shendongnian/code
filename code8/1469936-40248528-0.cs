    Dictionary<string, double> points = File
      .ReadLines(FILE_PATH)
     //.Where(line => !string.IsNullOrEmpty(line)) // you may want to filter out empty lines
      .Select(line => new {
         word = line,
         unique = word.Distinct().Count()
         total = word.Length })
      .ToDictionary(item => item.word, 
                    item => 15 * Math.PI * item.unique * item.unique / item.total);
