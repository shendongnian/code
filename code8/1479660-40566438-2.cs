    public static class DictionaryExtensions
    {
        public  static DataTable ToDataTable<T>(this Dictionary<string, T> dictionary)
        {
            var dt = new DataTable();
            dictionary.Keys.ToList().ForEach(x => dt.Columns.Add(x, typeof(T)));
            dt.Rows.Add(dictionary.Values.Cast<object>().ToArray());
            return dt;
        }
    }
