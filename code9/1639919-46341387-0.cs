    MySqlCommand command = new MySqlCommand(service.selectOnlyWorkerName(), connection);
    using (var reader = command.ExecuteReader())
    {
        SuspendLayout();
        while(reader.Read())
        {
            comboBox1.Items.Add(reader["worker_name"]);
        }
        ResumeLayout();
    }
