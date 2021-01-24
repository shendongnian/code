    var planets = new List<UserQuery.Planet>();
    using (var context = new GenerateKeyContext(db1))
    {
        planets = context.Planets.AsNoTracking().ToList();
    }
    using (var context = new InsertKeyContext(db2))
    {
        context.Planets.AddRange(planets);
        context.SaveChanges();
    }
