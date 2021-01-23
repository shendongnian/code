    private static readonly Dictionary<Type, DataFieldProperty[]> _propsCache = new Dictionary<Type, DataFieldProperty[]>();
    private static DataFieldProperty[] GetProperties(Type type) {
        lock (_propsCache) {
            if (!_propsCache.ContainsKey(type)) {
                var result = new List<DataFieldProperty>();
                foreach (var prop in type.GetProperties(BindingFlags.Instance | BindingFlags.Public)) {
                    var attr = prop.GetCustomAttribute<DataField>();
                    result.Add(new DataFieldProperty {
                        Name = attr?.Name ?? prop.Name,
                        Ignore = attr?.Ignore ?? false,
                        Property = prop
                    });
               }
               _propsCache.Add(type, result.ToArray());
            }
            return _propsCache[type];
        }
    }
    private class DataFieldProperty {
        public string Name { get; set; }
        public PropertyInfo Property { get; set; }
        public bool Ignore { get; set; }
    }
    private static void SetItemFromRow<T>(T item, DataRow row) where T : new() {
        // Get all properties with attributes.
        var props = GetProperties(item.GetType());
        foreach (DataColumn col in row.Table.Columns) {
            // Find property that matches the column name.
            var p = props.FirstOrDefault(c => c.Name == col.ColumnName && !c.Ignore);
            if (p != null) {
                if (row[col] != DBNull.Value) {
                    p.Property.SetValue(item, row[col], null);
                }
            }
        }
    }
