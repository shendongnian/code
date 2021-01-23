    var currentHash = MyHashingFunction(db.Model);
    if (db.GetService<IRelationalDatabaseCreator>().Exists()
        && !db.Set<ModelHash>().Any(mh => mh.Value == currentHash))
    {
        // Drop if changed
        db.Database.EnsureDeleted();
    }
    if (db.Database.EnsureCreated())
    {
        // Insert hash if created
        db.Add(new ModelHash { Value = currentHash });
        db.SaveChanges();
    }
