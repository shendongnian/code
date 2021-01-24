    IEnumerable<Type> types = new Type[]
    {
        typeof(LocationType),
        typeof(Location),
        typeof(Country),
        typeof(City)
    }
    .Aggregate(t =>
        modelBuilder.Entity(t).SetupEntity();
    }
    .ToList();
