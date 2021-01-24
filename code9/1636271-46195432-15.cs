    var persons = File.ReadLines(pathToFile)
                   .Select( line  => line.Split(','))
                   .GroupBy( pair => pair[0], 
                             pair => pair[1])
                   .Select( g => (Name=g.Key, Adjectives=g.ToArray())) 
                   .ToDictionary( person => person.Name,
                                  person => person);
