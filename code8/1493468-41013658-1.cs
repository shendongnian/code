    private static DataTable CreateDataTable(IEnumerable<int> ids) {
        DataTable table = new DataTable();
        table.Columns.Add("n", typeof(int));
        foreach (int id in ids) {
            table.Rows.Add(id);
        }
        return table;
    }
