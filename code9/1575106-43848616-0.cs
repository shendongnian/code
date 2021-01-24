    OleDbDataAdapter sqlArchiveData = new OleDbDataAdapter(sql_archive);
    
    DataTable dt = new DataTable();
    connProdcc1.Open();
    sqlArchiveData.Fill(dt);
    
    dt = AutoNumberedTable(dt);
    foreach (DataColumn column in dt.Columns)
    {
    	BoundField field = new BoundField();
    	field.DataField = column.ColumnName;
    	field.HeaderText = column.ColumnName.Replace("_"," ");
    	field.SortExpression = column.ColumnName;
    	AggregateGridView.Columns.Add(field);
    }
    AggregateGridView.DataSource = dt;
    AggregateGridView.DataBind();
    
    private DataTable AutoNumberedTable(DataTable SourceTable)
    {
    	DataTable ResultTable = new DataTable();
    	DataColumn AutoNumberColumn = new DataColumn();
    	AutoNumberColumn.ColumnName="S.No.";
    	AutoNumberColumn.DataType = typeof(int);
    	AutoNumberColumn.AutoIncrement = true;
    	AutoNumberColumn.AutoIncrementSeed = 1;
    	AutoNumberColumn.AutoIncrementStep = 1;
    	ResultTable.Columns.Add(AutoNumberColumn);
    	ResultTable.Merge(SourceTable);
    	return ResultTable;
    }
