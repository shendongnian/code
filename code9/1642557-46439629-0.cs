    var models = collection.AsQueryable()
     .SelectMany(g => g.Brands)
     .Select(y => y.Models)
     .SelectMany(x=> x);
    
    Console.WriteLine(models.Count());
