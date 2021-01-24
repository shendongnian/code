      // I don't have Animal class, that's why I've put string
      // Be sure that Animal implements Equals as well as GetHashCode methods
      var animalGroups = new List<List<string>> {
        new List<string> {"lizard", "cat", "cow", "dog"},
        new List<string> {"horse", "chicken", "pig", "turkey"},
        new List<string> {"ferret", "duck", "cat", "parrot"},
        new List<string> {"chicken", "sheep", "horse", "rabbit"}
      };
      var result = animalGroups
        .Select((list, index) => new {
          list = list,
          index = index, })
         .GroupBy(item => item.index % 2, // grouping 0, 2, ... 2n as well as 1, 3,... 2n - 1 
                  item => item.list)
         .Select(chunk => chunk
            .SelectMany(c => c)
            .Distinct()
            .ToList())
         .ToList();
