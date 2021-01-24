    using (var ctx = new Model())
    {
        var ent = new MyEntity
        {
            Id = Guid.Empty,
            Name = "Test"
        };
        try
        {
            var result = ctx.Database.ExecuteSqlCommand("INSERT INTO MyEntities (Id, Name) VALUES ( @p0, @p1 )", ent.Id, ent.Name);
        }
        catch (SqlException e)
        {
            Console.WriteLine("id already exists");
        }
    }
