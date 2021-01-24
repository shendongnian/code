    DataTable asset_table = rowData.asset_table;
    
    int colCount = asset_table.Columns.Count;
    for (int col = colCount - 1; colCount >= 0; colCount--)
    {
        string colName = asset_table.Columns[col].ColumnName;
        if (colName.Contains(""))
        {
            asset_table.Columns.Add("Temp Col", typeof(DateTime));
            foreach (DataRow row in asset_table.AsEnumerable())
            {
                DateTime date = DateTime.ParseExact((string)row[colName], "yyyyMMddhhmmss", CultureInfo.InvariantCulture);
                row["Temp Col"] = date;
            }
            asset_table.Columns.Remove(colName);
            asset_table.Columns["Temp Col"].ColumnName = colName;
            asset_table.Columns[colName].SetOrdinal(col);
        }
    }
