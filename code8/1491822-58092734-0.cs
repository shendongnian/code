      public DataTable myDataTable
      myDataTable = new DataTable("myName");
      myDataTable.Columns.Add("ID", typeof(Int32)); 
      myDataTable.Columns.Add(new DataColumn { ColumnName = "VALUE1", DataType = typeof(int), AllowDBNull = true });
      myDataTable.Columns.Add(new DataColumn { ColumnName = "VALUE2", DataType = typeof(int), AllowDBNull = true });
