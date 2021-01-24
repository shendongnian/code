        var myDataTable = new DataTable();
        foreach (var index1 in sortedColumns)
        {
            var columnName = myDataGrid.Columns[index1.Item2].ColumnName;
            myDataTable.Columns.Add(columnName, myDataGrid.Columns[index1.Item2].DataType);
        }
        foreach (DataRow dr in myDataGrid.Rows)
        {
            var itemArray = new object[allCols];
            var indexer = 0;
            foreach (var index2 in sortedColumns)
            {
                itemArray[indexer] = dr[index2.Item2];
                indexer += 1;
            }
            myDataTable.Rows.Add(itemArray);
        }
