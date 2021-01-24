    var result = MongoCollection
                .AsQueryable()
                .Where(x => x.Type == 1)
                .AsEnumerable()
                .OrderByDescending(x => Guid.NewGuid())
                .Take(20)
                .ToList();
