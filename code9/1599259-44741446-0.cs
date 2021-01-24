    using (MySqlConnection conns = new MySqlConnection(connString)) 
        {
            conns.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM table1", 
            conns2);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            
            //you do not need iterate through each column, you need to iterate through each row
            foreach(DataColumn column in dt.Columns)
            {
                //columnlistbox.Items.Add(dt2.Columns); //you do not need to add columns to the DataTable it already has the values
            }
            foreach(Datarow row in dt2.Rows) 
            {
                Console.Writeline(row["client_id"] + "," row["FirstName"]);
            }
            conn.Close();
        }
