    MySqlCommand command = new MySqlCommand(service.selectOnlyWorkerName(), connection);
    MySqlDataAdapter da = new MySqlDataAdapter(command);
    DataSet ds = new DataSet();
    da.Fill(ds,"workers");
    SuspendLayout();
    foreach ( var row in ds.Tables["workers"].Rows)
    {
        comboBox1.Items.Add(row[0]);
    }
    ResumeLayout();
