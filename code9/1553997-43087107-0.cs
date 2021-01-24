    public static DataTable SelectColumns(this DataTable dt, bool distinct, params int[] filters)
    {
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            DataColumn c = dt.Columns[i];
            if (!filters.Contains(i))
            {
                dt.Columns.Remove(c);
            }
        }
        return dt;
    }
