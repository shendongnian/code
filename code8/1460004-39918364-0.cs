        var conn = new SQLiteConnection(@"Data Source=yourSQLite.db;");
        conn.Open();
        var command = conn.CreateCommand();
        command.CommandText = "PRAGMA key = password;";
        command.ExecuteNonQuery();
        optionsBuilder.UseSqlite(conn);
