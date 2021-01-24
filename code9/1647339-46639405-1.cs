    namespace myProject.Common
    {
        public static class ExtensionMethods
        {
            public static object ToStringArray(this DataTable dt, params string[] columns)
            {
               
               return dt.AsEnumerable().Select(x => columns.Select(c => x[c].ToStringNullSafe()).ToArray()).ToArray();
               
            }
        }
        public static string ToStringNullSafe(this object obj)
        {
            return (obj ?? string.Empty).ToString();
        }
    }
