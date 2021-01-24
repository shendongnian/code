    using (var db = new MyDbContext())
    {
        db.Database.OpenConnection();
        try
        {
            var migrator = db.GetService<IMigrator>();
            foreach (var migration in db.Database.GetPendingMigrations())
            {
                migrator.Migrate(migration);
                // I don't expect you need a `db.Save` here
            }
        }
        finally
        {
            db.Database.CloseConnection();
        }
    }
