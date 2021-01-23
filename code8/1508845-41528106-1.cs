    public DataTable ReverseRowsInDataTable(DataTable inputTable)
    {
        DataTable outputTable = inputTable.Clone();
        for (int i = inputTable.Rows.Count - 1; i >= 0; i--)
        {
            outputTable.ImportRow(inputTable.Rows[i]);
        }
        return outputTable;
    }
