    using MySql.Data.MySqlClient;
    using MySql.Data.Types;
      string connStr = "server=localhost;user=root;database=world;port=3306;password=******;";
                
      using (MySqlConnection conn = new MySqlConnection(connStr);)
       {
           conn .Open();
       }
