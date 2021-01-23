     public static class GraphQlObjectParser
    {
        public static string Parse(string queryType, string queryName, string[] subSelection, object @object = null, string objectTypeName = null)
        {
            var query = queryType + "{" + queryName;
            if (@object != null)
            {
                query += "(";
                if (objectTypeName != null)
                {
                    query += objectTypeName + ":" + "{";
                }
                var queryData = string.Empty;
                foreach (var propertyInfo in @object.GetType().GetProperties())
                {
                    var value = propertyInfo.GetValue(@object);
                    if (value != null)
                    {
                        var type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                        var valueQuotes = type == typeof(string) ? "\"" : string.Empty;
                        var queryPart = char.ToLowerInvariant(propertyInfo.Name[0]) + propertyInfo.Name.Substring(1) + ":" + valueQuotes + value + valueQuotes;
                        queryData += queryData.Length > 0 ? "," + queryPart : queryPart;
                    }
                }
                query += (objectTypeName != null ? queryData + "}" : queryData) + ")";
            }
            if (subSelection.Length > 0)
            {
                query += subSelection.Aggregate("{", (current, s) => current + (current.Length > 1 ? "," + s : s)) + "}";
            }
            query += "}";
            return query;
        }
    }
