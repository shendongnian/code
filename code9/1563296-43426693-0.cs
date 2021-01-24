    using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), _sqliteDatabasePath))
    {
        conn.Open();
        SQLiteCommand sqlCommand = new SQLiteCommand("", conn);
    
        List<string> paramNames = new List<string>(); 
        for (int i = 0; i < dates.Count; i++)
        {
            paramNames.Add("@date" + i.ToString());
            sqlCommand.Parameters.AddWithValue("@date" + i.ToString(), dates[i]);
        }
        sqlCommand.CommandText =
            string.Format("DELETE FROM Trip WHERE Date IN ({0}) ", 
            string.Join(", ", paramNames));
        sqlCommand.ExecuteNonQuery();
    }
