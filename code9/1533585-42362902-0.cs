      DataTable dt = new DataTable();
      DataRow dr = null;
      dt.Columns.Add(new DataColumn { AutoIncrement=true,AutoIncrementSeed=1,AutoIncrementStep=1,ColumnName="SrNo",DataType=typeof(int)});
      dt.Columns.Add(new DataColumn { ColumnName = "Column1", DataType = typeof(string) });
      dt.Columns.Add(new DataColumn { ColumnName = "Column2", DataType = typeof(string) });
      dt.Columns.Add(new DataColumn { ColumnName = "Column3", DataType = typeof(string) });
      dt.Columns.Add(new DataColumn { ColumnName = "Column4", DataType = typeof(string) });
      for(int i=0;i<10;i++)
        dt.Rows.Add(dt.NewRow());
