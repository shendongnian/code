    DataTable dt = GetMyDataFromDatabase();
    if (dt.Rows.Count > 0)
    {
        if (!dt.Columns.Contains("MyColumn"))
        {
            //do whatever, maybe add the missing column?...
            dt.Columns.Add("MyColumn", typeof(String));
        }
    }
