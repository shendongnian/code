    var groupedData = from person in people
                      orderby person.Age
                      group person by person.Age into ageGroup
                      select new { Age = ageGroup.Key, MaxWeight = ageGroup.Max(p => p.Weight) };
    groupedData.ToList().ForEach(g =>
    {
        Console.WriteLine("{0}, {1}", g.Age, g.MaxWeight);
    });
