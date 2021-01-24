    public bool EmptyDataTable(DataTable dt)
    {
        if (dt == null || dt.Rows.Count < 1)
        return true;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
             if (!string.IsNullOrWhiteSpace(dt.Rows[i].Field<string>("columnName")))
             {
                 return false;
             }
         }
         return true;
    }
