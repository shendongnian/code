    using (var command = new SQLiteCommand(sql, m_dbConnection))
    using (var reader = command.ExecuteReader())
    {
        if (reader.HasRows)
        {
            reader.Read();
            return reader.GetString(1);
        }
        else 
            return "";
    }
