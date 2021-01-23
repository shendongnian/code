     MySql.Data.MySqlClient.MySqlConnection conn;
     string myConnectionString;
     myConnectionString = "server=xxxx;uid=xxx;" +     
     "pwd=xxxx;database=xxx;";
     try
     {
         conn = new MySql.Data.MySqlClient.MySqlConnection();
         conn.ConnectionString = myConnectionString;
         conn.Open();
     }
     catch (MySql.Data.MySqlClient.MySqlException ex)
     {
         MessageBox.Show(ex.Message);
     }
