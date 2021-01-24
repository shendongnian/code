    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("RCDID", typeof(int)),
                new DataColumn("EmployeeID", typeof(int)),
                new DataColumn("LogDate", typeof(string)),
                new DataColumn("LogTime", typeof(string)),
                new DataColumn("TerminalID", typeof(string)),
                new DataColumn("InOut   ", typeof(int)),
            });
            dt.Rows.Add(1682284, 362426, "07/01/2017", "08:38:46", "HO001", 0);
            dt.Rows.Add(1682286, 362426, "07/02/2017", "08:32:04", "HO001", 0);
            dt.Rows.Add(1682287, 362426, "07/02/2017", "08:32:06", "HO001", 0);
            dt.Rows.Add(1682289, 362426, "07/03/2017", "08:35:08", "HO001", 0);
            dt.Rows.Add(1682291, 362426, "07/04/2017", "08:38:23", "HO001", 0);
            dt.Rows.Add(1682292, 362426, "07/04/2017", "08:38:25", "HO001", 0);
            var result = dt.GetValueFromColumnByColumn("LogDate", "07/04/2017", "LogTime");
        }
    }
    public static class DataTableExtension
    {
        public static object GetValueFromColumnByColumn(this DataTable dataTable, string byColumn, object valueOfByColumn, string fromColumn)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                if (row[byColumn] == valueOfByColumn)
                {
                    return row[fromColumn];
                }
            }
            return null;
        }
    }
