        private DataTable ListToDataTable<T>(List<T> objs, string tableName) {
            var table = new DataTable(tableName);
            var lists = new List<List<object>>();
            // init columns
            var propertyInfos = new List<PropertyInfo>();
            foreach (var propertyInfo in typeof(T).GetProperties()) {
                propertyInfos.Add(propertyInfo);
                if(propertyInfo.PropertyType.IsEnum || propertyInfo.PropertyType.IsNullableEnum()) {
                    table.Columns.Add(propertyInfo.Name, typeof(int));
                } else {
                    table.Columns.Add(propertyInfo.Name, Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType);
                }
                table.Columns[table.Columns.Count - 1].AllowDBNull = true;
            }
            // fill rows
            foreach(var obj in objs) {
                var list = new List<object>();
                foreach(var propertyInfo in propertyInfos) {
                    object currentValue;
                    if(propertyInfo.PropertyType.IsEnum || propertyInfo.PropertyType.IsNullableEnum()) {
                        var val = propertyInfo.GetValue(obj);
                        if(val == null) {
                            currentValue = DBNull.Value;
                        } else {
                            currentValue = (int)propertyInfo.GetValue(obj);
                        }
                    } else {
                        var val = propertyInfo.GetValue(obj);
                        currentValue = val ?? DBNull.Value;
                    }
                    list.Add(currentValue);
                }
                lists.Add(list);
            }
            lists.ForEach(x => table.Rows.Add(x.ToArray()));
            return table;
        }
