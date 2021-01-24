    System.Data.SQLite.SQLiteConnection.CreateFile("sqlite.db3");
    
    using(System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("data source=sqlite.db3")){
        using(System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(conn)){
            conn.Open();
            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS
                                [persons](
                                [id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                [name] VARCHAR(50) NULL
                                )";
                                
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "INSERT INTO [persons] (name) values('Atlas')";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "SELECT * FROM [persons]";
            
            using(System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader()){
                while(reader.Read()){
                    MessageBox.Show(reader["name"].ToString());
                }
                
            conn.Close();
            
            }
            
        }
    }
