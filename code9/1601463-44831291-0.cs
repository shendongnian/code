    var dbFactory = new OrmLiteConnectionFactory(
        sqlServerConnString,
        SqlServerDialect.Provider); 
    db.RegisterConnection("sqlite", "db.sqlite", SqliteDialect.Provider);
    using (var dbSqlite = dbFactory.OpenDbConnection("sqlite"))
    {
        db.CreateIfNotExist<Poco>(); // Create tables in SQLite if needed
    }
    using (var db = dbFactory.OpenDbConnection())
    {
        var rows = db.Select<Poco>();
        using (var dbSqlite = dbFactory.OpenDbConnection("sqlite"))
        {
            db.InsertAll(rows);
        }
    }
