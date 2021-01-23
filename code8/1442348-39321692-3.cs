    private DataTable LoadData()
    {
        var dt = new DataTable();
        dt.Columns.Add("ExistingColumn");
        dt.Rows.Add("x");
        dt.Rows.Add("y");
        dt.Rows.Add("z");
        return dt;
    }
