    using(MySqlConnection connection = new MySqlConnection(MyConnectionString))
    using(MySqlCommand cmd = connection.CreateCommand())
    {
        connection.Open();
        cmd.CommandText = "SELECT pb.Id, pb.Name, pb.MobileNo, e.email FROM phonebook pb INNER JOIN email e ON e.Id= pb.Id";
        MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adap.Fill(ds);
        dataGridView1.DataSource = ds.Tables[0].DefaultView;
    }
