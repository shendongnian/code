    private void GroupContent<T>(List<T> dataList, string[] columns, string[] columnsToExclude)
        {
    string[] columnsToGroup = columns.Except(columnsToExclude).ToArray();
            EqualityComparer<IDictionary<string, object>> equalityComparer = new EqualityComparer<IDictionary<string, object>>();
            var groupedList = dataList.GroupBy(x =>
            {
                var groupByColumns = new System.Dynamic.ExpandoObject();
                ((IDictionary<string, object>)groupByColumns).Clear();
                foreach (string column in columnsToGroup)
                    ((IDictionary<string, object>)groupByColumns).Add(column, GetPropertyValue(x, column));
                return groupByColumns;
            }, equalityComparer);
            foreach (var item in groupedList)
            {
                Console.WriteLine("Group : " + string.Join(",", item.Key));
                foreach (object obj in item)
                    Console.WriteLine("Item : " + obj);
                Console.WriteLine();
            }
        }
        private static object GetPropertyValue(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
        }
