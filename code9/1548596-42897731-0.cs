    private bool BusinessRulesOne(DataTable dt, DataColumn dc)
    {
        DataRow[] checkColumn = dt.Select(dc.ColumnName + " not in (1,2,3)");
    
        return checkColumn.Length == 0;
    }
