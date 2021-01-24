    _persons = File.ReadLines(pathToFile)
                   .Select( line  => line.Split(","))
                   .GroupBy( pair => pair[0], 
                             pair => pair[1])
                   .ToDictionary( g => g.Key,
                                  new Person{ Name=g.Key, Adjectives=g.ToArray()});
