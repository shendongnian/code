    int tableSize = 100;               // for example
    DataSet allTables = new DataSet(); // or List<DataTable>
    for (int i = 0; i < bigTable.Rows.Count; i += tableSize)
    {
        DataTable tbl = bigTable.Clone(); // same columns, empty
        for (int ii = 0; ii < tableSize; ii++)
        {
            if (i + ii == bigTable.Rows.Count) break;
            tbl.ImportRow(bigTable.Rows[i + ii]);
        }
        allTables.Tables.Add(tbl);
    }
