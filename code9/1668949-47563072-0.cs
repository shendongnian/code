    DataSet DataSet1 = new dataset
    
    dataset1.Tables.Add("Main");
    foreach(DataGridViewColumn col in GridView.Columns)
    {
        string name = col.Name.ToString();
        DataSet1.Tables["Main"].Columns.Add(name);
        DataSet1.AcceptChanges();
    }
    foreach(DataGridViewRow row in GridView.Rows)
    {
        string value1 = row.Cells[0].Value.ToString();
        string value2 = row.Cells[1].Value.ToString();
        DataSet1.Tables["Main"].Rows.Add(value1,value2);
        DataSet1.AcceptChanges();
    }
