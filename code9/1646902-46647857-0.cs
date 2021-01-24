    var resultsCount = MongoCollection
                      .AsQueryable()
                      .Where(x => x.Type == 1)
                      .Count();
  
    var randomSkip = (new Random()).Next(0, resultsCount - 20);
    var result = MongoCollection
                .AsQueryable()
                .Where(x => x.Type == 1)
                .Skip(randomSkip)
                .Take(20)
                .ToList();
