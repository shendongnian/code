    var result = animalData.GroupBy(x => x.AnimalType).Select(g => new AnimalObject 
                 {
                     Name = g.Key,
                     Number = g.Count()
                 }).ToList();
    foreach (var e in result)
        Console.WriteLine($"Name: {e.Name} \n NumberAppearances: {e.Count}");
