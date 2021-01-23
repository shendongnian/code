    DataTable dTable = new DataTable();
    conn.Open();
    string query = "SELECT * FROM test_db.users;";
    MysqlCommand cmd = new MySqlCommand(query, conn);
    using (MySqlDataAdapter reader = new MySqlDataAdapter(cmd))
    {
        adapter.Fill(dTable);
    }
    dgUsers.DataSource = dTable;
    conn.Close();
