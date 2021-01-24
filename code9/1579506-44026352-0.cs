    System.Collections.ArrayList list = new System.Collections.ArrayList();
    using (var db = new SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
    {
        db.Open();
        const string sql = "select * from Events";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
            list.Add(new { Name = reader["name"].ToString() });
    }
    lstPersons.ItemsSource = list;
