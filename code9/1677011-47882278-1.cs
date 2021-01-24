       using(MySqlConnection con = new MySqlConnection(constring))
       {
       MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM table1,con);
       DataTable dt = new DataTable();
       adp.Fill(dt);
       IEnumerable<DataRow> query = adp.Where(x => x.Column2 == 'dog').ToList();
       DataTable filteredRows = query.CopyToDataTable<DataRow>();
       
       adp.Dispose();
       }
