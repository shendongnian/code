    string sql = String.Format("insert into {0}({1}) values({2});", tableName, columns, values);
    using (SQLiteConnection myConn = new SQLiteConnection(dbConnection))
    {
        try
        {
            myConn.Open();
    
            using (SQLiteCommand sqCommand = new SQLiteCommand(sql, myConn))
            {
                sqCommand.CommandText = sql;
                int rows = sqCommand.ExecuteNonQuery();
                return !(rows == 0);
            }
        }
        catch (Exception e)
        {
            // do exception handling
        }
    }
