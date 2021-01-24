    protected void Page_Load(object sender, EventArgs e)
    {
        //TODO: do not hardcode connction string, move it to settings
        string connectionString = 
          @"Data Source=C:/Users/elias/Documents/Visual Studio 2017/WebSites/WebSite7/App_Data/overhoren.db";
        // var for simplicity 
        using (var conn = new System.Data.SQLite.SQLiteConnection(connectionString))
        {
            conn.Open();
            using (var command = new System.Data.SQLite.SQLiteCommand(conn))
            {
                command.Connection = conn;
    
                //TODO: put the right SQL to perform here 
                command.CommandText = 
                   @"select name, 
                            score
                       from MyTable";
    
                using (var reader = command.ExecuteReader()) {
                  string test = "";
    
                  // do we have data to read?
                  //DONE: try not building string but using formatting (or string interpolation)
                  if (reader.Read())
                    test = $"Name: {reader["name"]}\tScore: {reader["score"]}";
 
                  //TODO: so you've got "test" string, do want you want with it
                }
            }
            //DONE: you don't want command.ExecuteNonQuery(), but command.ExecuteReader()
            //DONE: you don't want conn.Close() - "using" will do it for you 
        }
    }
