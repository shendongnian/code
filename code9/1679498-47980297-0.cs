    List<string> containsKeys = new List<string>();
    containsKeys.Add("SomeWildCard");
    
    DataTable dt = new DataTable();
    string[] columnNames = dt.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray().Where(t => containsKeys.Contains(t)).ToArray();
