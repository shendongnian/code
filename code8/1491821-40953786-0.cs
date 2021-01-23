    public DataTable myDataTable
    myDataTable = new DataTable("myName");
    myDataTable.Columns.Add("ID", typeof(Int32)); 
    DataColumn dc = myDataTable.Columns.Add("value1", typeof(Int32)); 
    dc.AllowDBNull = true;
