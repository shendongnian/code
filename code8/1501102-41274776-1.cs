    var result = collection.Aggregate()
                            .Group(
                                x => x.SomeStringField,
                                g => new {
                                      Result = g.Select(
                                               x => x.SomeNumberField
                                               ).Max()
                                }
                            ).ToList();
    result.ForEach(doc => Console.WriteLine(doc.ToJson()));
