    public static DataTable SelectColumns(this DataTable dt, bool distinct, params int[] filters)
    { 
        for (int i = dt.Columns.Count - 1; i >= 0; i--)
        {
            DataColumn c = dt.Columns[i];
            if (!filters.Contains(c.Ordinal))
            {
                dt.Columns.Remove(c);
            }
        }
        return dt;
    }
