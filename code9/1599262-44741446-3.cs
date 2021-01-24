         using (MySqlConnection conn = new MySqlConnection(connString)) 
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM table1", 
            conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            
            //display your dataset in a ASP.NET Web Forms DataGrid
            dataGrid.DataSource = dt;
            dataGrid.DataBind();
            //conn.Close();// you do not need this, your using statements call Dispose and Dispose will release the connection back to the connection pool
        }
