    [TestMethod]
    public void LaCreationBaseMarche()
    {
        string dataSource = "exemple.db";
        SqliteBase.CreerBase(dataSource);
        SQLiteConnection connection = new SQLiteConnection();
    
        connection.ConnectionString = "Data Source=" + dataSource;
        connection.Open();
        SQLiteCommand command = new SQLiteCommand(connection);
        command.CommandText = "SELECT name FROM exemple WHERE type = 'table' AND name = 'beispiel';";
        SQLiteDataReader reader = command.ExecuteReader();
    
        while (reader.Read())
        {
            Assert.Equals("beispiel", reader[0].ToString());
        }
        
        reader.Close();
        reader.Dispose();
        command.Dispose();
    }
