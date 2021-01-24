    _persons = csvRows.GroupBy(
                                pair=>pair.Item1, //The key to group by
                                pair=>pair.Item2  //The group's contents
                          )
                         .ToDictionary(
                                g=>g.Key,
                                new Person{
                                            Name=g.Key,
                                            Adjectives=g.ToArray()
                                }
                          );
