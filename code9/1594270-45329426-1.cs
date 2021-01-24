    public void Init()
    {
      var model = _modelBuilder.Build(Database.Connection);
      IDatabaseCreator sqliteDatabaseCreator = new SqliteDatabaseCreator();
      sqliteDatabaseCreator.Create(Database, model);
    }
