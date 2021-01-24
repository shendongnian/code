       using(MySqlConnection con = new MySqlConnection(constring))
       {
       MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM table1 WHERE Column2='dog'",con);
       DataTable dt = new DataTable();
       adp.Fill(dt);
       adp.Dispose();
       }
