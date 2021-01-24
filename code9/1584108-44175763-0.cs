    public static class ExtensionMethods
    {
        public static object ToStringArray(this DataTable dt, params string[] columns)
        {
            //if specifically columns are provided then returns item array values for these columns.
            if (columns != null && columns.Length > 0)
            {
                return dt.AsEnumerable().Select(x => columns.Select(c => x[c])).ToArray();
            }
            else
            {
                return dt.AsEnumerable().Select(x => new[] { x.ItemArray }).ToArray();
            }
        }
    }
