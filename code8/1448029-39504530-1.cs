    private static void RemoveById(DataTable dataTable, int id)
    {
        var column = dataTable.Columns["ID"];
        if (column == null)
            return;
        var rows = dataTable.Rows;
        for (int index = rows.Count - 1; index >= 0; index--)
        {
            var row   = rows[index];
            var value = row ["ID"];
            if (value == null)
                continue;
            if (value.Equals(id))
            {
                rows.RemoveAt(index);
                return;
            }
        }
    }
