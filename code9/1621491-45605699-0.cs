    public void Method1()
    {
        DataTable dt1 = ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 ? ds.Tables[0] : new DataTable();
        DataTable dt2 = ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0 ? ds.Tables[1] : new DataTable();
        DataTable dt3 = ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0 ? ds.Tables[2] : new DataTable();
    }
