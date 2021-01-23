    using(SQLiteConnection conn= new SQLiteConnection(@"Data Source=C:\Program Files (x86)\myCompany\myScanApp\test.s3db;"))
    {
        conn.Open();
    
        SQLiteCommand command = new SQLiteCommand("Select * from yourTable", conn);
        SQLiteDataReader reader = command.ExecuteReader();
    
        while (reader.Read())
           Console.WriteLine(reader["YourColumn"]);
    
     
        reader.Close();
    }
