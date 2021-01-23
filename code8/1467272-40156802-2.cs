    public static class LocalExtensions
    {
        public static List<T> DataTableToList<T>(this DataTable table) where T : class
        {
            //Map the properties in a dictionary by name for easy access
            var propertiesByName = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary(p => p.Name);
            var columnNames = table.Columns.Cast<DataColumn>().Select(dc => dc.ColumnName);
            //The indexer property to access DataRow["columnName"] is called "Item"
            var property = typeof(DataRow).GetProperties().First(p => p.Name == "Item" 
                && p.GetIndexParameters().Length == 1 
                && p.GetIndexParameters()[0].ParameterType == typeof(string));
            var paramExpr = Expression.Parameter(typeof(DataRow), "r");
            var newExpr = Expression.New(typeof(Test));
            //Create the expressions to map properties from your class to the corresponding
            //value in the datarow. This will throw a runtime exception if your class 
            //doesn't contain certain columnnames!
            var memberBindings = columnNames.Select(columnName =>
            {
                var pi = propertiesByName[columnName];
                var indexExpr = Expression.MakeIndex(paramExpr, property, 
                    new[] { Expression.Constant(columnName) });
                //Datarow["columnName"] is of type object, cast to the right type
                var convert = Expression.Convert(indexExpr, pi.PropertyType);
                return Expression.Bind(pi, convert);
            });
            var initExpr = Expression.MemberInit(newExpr, memberBindings);
            var func = Expression.Lambda<Func<DataRow, T>>(initExpr,paramExpr).Compile();
            return table.Rows.Cast<DataRow>().Select(func).ToList();
        }
    }
