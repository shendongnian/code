    var db1 = @"Server=(localDB)\MSSQLLocalDB;Integrated Security=true;Database=GuidGen";
    var db2 = @"Server=(localDB)\MSSQLLocalDB;Integrated Security=true;Database=GuidInsert";
    // Set initializers:
    // 1. just for testing.
    Database.SetInitializer(new DropCreateDatabaseAlways<GenerateKeyContext>());
    // 2. prevent model check.
    Database.SetInitializer<InsertKeyContext>(null);
    using (var context = new GenerateKeyContext(db1))
    {
        var earth = new Planet { Name = "Earth", };
        var mars = new Planet { Name = "Mars", };
        context.Planets.Add(earth);
        context.Planets.Add(mars);
        context.SaveChanges();
    }
