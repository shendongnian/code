    public static class DataTableToList
    {
        public static List<T> ToList<T>(this DataTable dataTable)
            where T:class,new()
        {
            var list = new List<T>();
            var typeOfT = typeof(T);
            foreach (DataRow row in dataTable.Rows)
            {
                var t = new T();
                foreach (DataColumn column in dataTable.Columns)
                {
                    var propertyName = column.ColumnName;                    
                    var property = t.GetType().GetProperty(propertyName);
                    if (property != null)
                    {
                        property.SetValue(t, Convert.ChangeType(row[column],property.PropertyType,null));
                    }
                }
                list.Add(t);
            }
            return list;
        }
    }
