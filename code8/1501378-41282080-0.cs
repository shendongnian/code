    DataTable Pivot(DataTable dt, DataColumn pivotColumn, DataColumn pivotValue)
        {
            // find primary key columns 
            //(i.e. everything but pivot column and pivot value)
            DataTable temp = dt.Copy();
            temp.Columns.Remove( pivotColumn.ColumnName );
            temp.Columns.Remove( pivotValue.ColumnName );
            string[] pkColumnNames = temp.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray();
    
        // prep results table
        DataTable result = temp.DefaultView.ToTable(true, pkColumnNames).Copy();
        result.PrimaryKey = result.Columns.Cast<DataColumn>().ToArray();
        dt.AsEnumerable().Select(r => r[pivotColumn.ColumnName].ToString()).Distinct().ToList().ForEach (c => result.Columns.Add(c, pivotColumn.DataType));
    
        // load it
        foreach( DataRow row in dt.Rows ) 
        {
            // find row to update
            DataRow aggRow = result.Rows.Find(pkColumnNames.Select( c => row[c]).ToArray());
            // the aggregate used here is LATEST 
            // adjust the next line if you want (SUM, MAX, etc...)
            aggRow[row[pivotColumn.ColumnName].ToString()] = row[pivotValue.ColumnName];
        }
        return result;
    }
