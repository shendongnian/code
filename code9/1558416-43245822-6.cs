    private void ValidateRows(DataTable csvDataTable)
    {
        DataTable invalidatedTable = new DataTable();
        invalidatedTable = csvDataTable.Clone();
        List<Func<DataRow, bool>> validators = new List<Func<DataRow, bool>>
        {
            row => row["ID"].ToString() == "",
            row => row["Name"].ToString() != "test",
        };
        // Loop over all the rows in the datatable
        foreach (DataRow row in csvDataTable.Rows)
        {
            bool valid = validators.All(validator => validator(row));
            if (!valid)
            {
                invalidatedTable.Rows.Add(row.ItemArray);
            }
        } // End Loop  
    }
