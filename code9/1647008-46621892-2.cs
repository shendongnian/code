    private DataTable MergeOnUniqueColumnAfterLastID(DataTable smallTable, DataTable bigTable, string uniqueColumn)
    {
        DataTable m = smallTable;
        int maxUnique = Convert.ToInt32(m.Compute("max([" + uniqueColumn + "])", string.Empty));
        for (int i = 0; i < bigTable.Rows.Count; i++)
        {
            if (!(smallTable.AsEnumerable().Any(row => (int)bigTable.Rows[i][uniqueColumn] <= maxUnique)))
            {
                smallTable.Rows.Add(bigTable.Rows[i].ItemArray);
            }
        }
        return m;
    }
