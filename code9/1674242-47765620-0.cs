    public static string DataTableToJSON(DataTable table)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        string[] keys = new string[] { "Name", "Value", "Unit", "MinValue", "MaxValue" };
        foreach(DataRow dr in table.Rows)
        {
            Dictionary<string, object> row = new Dictionary<string, object>();
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach(DataColumn col in table.Columns)
            {
                if(keys.Contains(col.ColumnName)) dict.Add(col.ColumnName, dr[col]);
                else row.Add(col.ColumnName, dr[col]);
            }
            row.Add("VitalThreshold", dict);
            rows.Add(row);
        }
        serializer.MaxJsonLength = int.MaxValue;
        return serializer.Serialize(rows);
    }
