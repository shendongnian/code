    var dataSet = new DataSet();
    
    var dataTable = new DataTable("Mem");
    
    dataTable.Columns.Add(new DataColumn("Name", typeof(String)));
    dataTable.Columns.Add(new DataColumn("Code", typeof(String)));
    dataTable.Columns.Add(new DataColumn("Plan", typeof(String)));
    
    var newRow = dataTable.NewRow();
    
    newRow["Name"] = "Foo";
    newRow["Code"] = "Bar";
    newRow["Plan"] = "Zaz";
    
    dataTable.Rows.Add(newRow);
    
    dataSet.Tables.Add(dataTable);
