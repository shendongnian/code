    var totlaCol= dt.Columns.Cast<DataColumn>().SingleOrDefault(col => col.ColumnName == "SubTotal");
    if (totalCol!= null)
    {
        var tableRows = dt.AsEnumerable().First();
        var sumVal= tableRows.Field<string>(totlaCol);
        // or 
        //sumVal = tableRows.Field<string>(dt.Columns.IndexOf(myColumn));
    }
