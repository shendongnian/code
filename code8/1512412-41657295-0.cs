     private static SQLiteConnection GetConnectionString(string path)
            {
                var con= new SQLiteConnection()
                {
                    ConnectionString =
                  new SQLiteConnectionStringBuilder()
                  { DataSource = path, ForeignKeys = true,BinaryGUID = false }
                  .ConnectionString
                };
    
                return con;
            }
