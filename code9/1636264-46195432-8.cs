    class Person
    {
        public string Name{get;}
        public string[] Adjectives{get;}
        Person(string Name,IEnumerable<string> adjectives)
        {
            Name=name;
            Adjectives=adjectives.ToArray();
        }
    }
    _persons = File.ReadLines(pathToFile)
                   .Select( line  => line.Split(","))
                   .GroupBy( pair => pair[0], 
                             pair => pair[1])
                   .ToDictionary( g => g.Key,
                                  new Person(g.Key, g));
