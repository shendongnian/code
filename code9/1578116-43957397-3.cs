    int groupSize = 5;
    var foo = My100List.GroupBy(x => x.Sex)
                       .SelectMany(g => g.Select((x, i) => new { Person = x, Group = i / groupSize}))
                       .GroupBy(x => x.Group)
                       .Select(g => new Group
                       {
                           Name = "Group" + g.Key,
                           Persons = g.Select(x => x.Person).ToList()
                       });
