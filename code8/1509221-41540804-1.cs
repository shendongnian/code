    var dataSet = new DataSet();
    
    for (var i = 0; i < Mem.Length; i++)
    {
        var dataTable = new DataTable();
    
        dataTable.Columns.Add(new DataColumn("Name", typeof(String)));
        dataTable.Columns.Add(new DataColumn("Code", typeof(String)));
        dataTable.Columns.Add(new DataColumn("Plan", typeof(String)));
    
        // change the logic to extract all values from line
        var values = Mem[i].Split(',');
    
        var newRow = dataTable.NewRow();
    
        newRow["Name"] = values[0];
        newRow["Code"] = values[1];
        newRow["Plan"] = values[2];
    
        dataTable.Rows.Add(newRow);
    
        dataSet.Tables.Add(dataTable);
    }
