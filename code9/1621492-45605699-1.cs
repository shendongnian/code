    public void Method1()
    {
        List<DataTable> dataTables = new List<DataTable>();
        foreach (DataTable dataTable in ds.Tables)
        {
            if (dataTable.Rows.Count > 0) dataTables.Add(dataTable);
        }
    }
