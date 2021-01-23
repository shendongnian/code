    public static string DataTableToCSV(this DataTable datatable, char seperator)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < datatable.Columns.Count; i++)
        {
            sb.Append(datatable.Columns[i]);
            if (i < datatable.Columns.Count - 1)
                sb.Append(seperator);
        }
        sb.AppendLine();
        foreach (DataRow dr in datatable.Rows)
        {
            for (int i = 0; i < datatable.Columns.Count; i++)
            {
                sb.Append(dr[i].ToString());
    
                if (i < datatable.Columns.Count - 1)
                    sb.Append(seperator);
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
