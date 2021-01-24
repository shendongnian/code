    //clone dt1, copies all the columns to newTable 
    DataTable newTable = dt1.Clone();
    
    //copies all the columns from dt2 to newTable 
    foreach(var c in dt2.Columns)
        newTable.Columns.Add(c);
    //now newTable has all the columns from the original tables combined
    
    //iterates over collection
    foreach (var item in collection) {
        //creates newRow from newTable
        DataRow newRow = newTable.NewRow();
        //iterate the columns, gets values from either original table if column name is there
        foreach(var c in newTable.Columns)
            newRow[c.ColumnName] = item.T1.ContainsColumn(c.ColumnName) ?  item.T1[c.ColumnName] : item.T2[c.ColumnName];
        newTable.Rows.Add(newRow);
    }
