    var columnsToRemove = new List<DataColumn>();
    foreach(var column in dataTable.Columns)
    {
        if(BusinessRulesSatisfied(dataTable, column) == false)
        {
            columnsToRemove.Add(column);
        }
    }
