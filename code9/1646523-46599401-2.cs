    public static class DataTableExtensions
    {
        public static int CountChequeStatus(this DataTable table, string condition)
        {
            var count = table.Compute("Count(ChequeStatus)", $"ChequeStatus = '{condition}'");
            return count == DbNull.Value ? 0 : (int)count;
        }
    }
