    using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), _sqliteDatabasePath))
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("DELETE FROM Trip ");
        sb.Append("WHERE Date IN ( ? ");
        if (dates.Count > 1)
        {
            for (int i = 1; i < dates.Count; i++)
            {
                sb.Append(", ? ");
            }
        }
        sb.Append(")");
        conn.BeginTransaction();
        conn.Execute(
            sb.ToString(),
            dates.Cast<object>().ToArray());
        conn.Commit();
    }
