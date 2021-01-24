    DataTable table = new DataTable();
    table.Columns.Add("#");
    table.Columns.Add("Delay");
    foreach (var line in raw_text)
    {
        DataRow row = table.NewRow();
        row[0] = line[0]; // The # value you want.
        row[1] = line[1]; // The Delay value you want.
        table.Rows.Add(row);
    }
    DataGridView1.DataSource = table;
    DataGridView1.DataBind();
