    string dataSource = @"Data Source=c:\users\Fred\desktop\test.db;Version=3;Page Size=1024;";
                SQLiteConnection conn = new SQLiteConnection(dataSource);
                conn.Open();
                conn.ChangePassword("ABCD");
                conn.Close(); 
