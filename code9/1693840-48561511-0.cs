    public static class Utils
    {
        public static void CopyRows(this DataTable from, DataTable to, int min, int max)
        {
            for (int i = min; i < max && i < from.Rows.Count; i++)
                to.ImportRow(from.Rows[i]);
        }
    }
