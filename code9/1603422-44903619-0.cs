    String connectionString = @"Data Source=D:\Users\wkhan2\Downloads\chinook\chinook.db";
            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(connectionString);
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand("select * from table");
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteScalar();
            System.Data.SQLite.SQLiteDataAdapter da = new System.Data.SQLite.SQLiteDataAdapter(cmd);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
