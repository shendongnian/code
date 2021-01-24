    public void cbFeiertagebefüllen(FeiertageEntfernen feiertagentfernen)
    {
        string Query = @"select bezeichnung from feiertage";
        using (var command = new SQLiteCommand(Query, sqlite_conn))
        {
            if (sqlite_conn.State != ConnectionState.Open)
            {
                sqlite_conn.Open();
            }
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string übergabe = reader.GetString(0);
                    feiertagentfernen.cbFeiertag.Items.Add(übergabe);
                }
            }
        }
    }
