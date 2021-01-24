    using(MySqlConnection connection = new MySqlConnection(connectionString)){
        using(MySqlCommand cmd = new MySqlCommand(query, connection)){
              foreach(MySqlParameter p in parameters)
              {
                  cmd.Parameters.Add(p);
              }
    
               connection.Open();
               DataTable dt = new DataTable();
               using(MySqlDataReader reader = cmd.ExecuteReader()){
                   dt.Load(reader);
                   return dt;
               }
           }
      }
