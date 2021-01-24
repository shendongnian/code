        private void Request(string request) {
        var dt = new DataTable();
        try {
            MySqlCommand cmd = new MySqlCommand(request, connectionString);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                dt.Load(reader);
                if (reader.IsClosed) break;
            }
            reader.Close();
        } catch (MySql.Data.MySqlClient.MySqlException ex) {
            Console.WriteLine(ex);
        }
        dataGridView1.DataSource = dt;
    }
