    DataSet dataSet = new DataSet();
    DataTable dt = new DataTable();
    dt.Columns.Add("Name", typeof(string));
    dt.Columns.Add("Counter", typeof(string));
    foreach (string line in lines)
    {
        var values = line.Split(new[] { ',' });
        DataRow row = dt.NewRow();  
        row["Name"] = values[0];
        row["Counter"] = values[1];
        dt.Rows.Add(row);
    }
