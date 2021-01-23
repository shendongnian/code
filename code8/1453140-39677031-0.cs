      SQLiteConnection connection = new SQLiteConnection("Data Source=" + sFileName + "; Version=3;", true);
        connection.Open();
        SQLiteCommand mycommand = new SQLiteCommand(connection);
        mycommand.CommandText = "PRAGMA foreign_keys=ON";
        mycommand.ExecuteNonQuery();
       connection.Close();
