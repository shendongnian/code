     public void populateDGV()
            {
                // populate the datagridview
                string selectQuery = "SELECT * FROM park";
                DataTable table = new DataTable();
               //connection open here
               openConnection()
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
                adapter.Fill(table);
                dataGridView_USERS.DataSource = table;
            }
