        using(MySqlConnection con = new MySqlConnection(constring))
       {
          MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM table1",con);
          DataTable dt = new DataTable();
          adp.Fill(dt);
          adp.Dispose();
         
          DataRow[] dr=dt.select(“Column2=‘Dog’”);
      }
