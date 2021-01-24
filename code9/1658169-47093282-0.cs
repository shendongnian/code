    string query = "SELECT Id FROM dbAllServers WHERE Server_Names=@server_name";
    
    string serverName = cmb_SQLNames.SelectedValue;
    
    using (SQLiteConnection connection = new SQLiteConnection(GetConnectionString()))
    {
        connection.Open();
        using (var cmd = new SQLiteCommand(query, connection))
        {
            cmd.Parameters.Add(new SQLiteParameter("@server_name", serverName));
            using (var rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    // do your job  here
                }
            }
        }
    }
