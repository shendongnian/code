    DataTable dt = new DataTable();
    dt.Columns.Add("Descrição");
    foreach (ManagementObject queryObj in searcher8.Get())
    {    
        dt.Rows.Add(new object[] { queryObj["Description"] });
    }
    dataGridView1.DataSource = dt;
