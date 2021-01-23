    public static class DictionaryExtensions
    {
        public static DataTable ToDataTable<T>(this Dictionary<string, T> dictionary)
        {
            var dt = new DataTable();
            dictionary.Keys.ToList().ForEach(x => dt.Columns.Add(x, typeof(T)));
            dt.Rows.Add(dictionary.Values.Cast<object>().ToArray());
            return dt;
        }
        public static void UpdateFromDataTable<T>(this Dictionary<string, T> dictionary, 
            DataTable table)
        {
            if (table.Rows.Count == 1)
                table.Columns.Cast<DataColumn>().ToList().ForEach(x => 
                    dictionary[x.ColumnName] = table.Rows[0].Field<T>(x.ColumnName));
        }
    }
