        public static long InsertB<T>(this SqlConnection sqlConnection, T obj)
        {
            Dictionary<string, object> propertyValuesMap = new Dictionary<string, object>();
            var columns = new StringBuilder();
            var values = new StringBuilder();
            var tableName = ((TableAttribute)obj.GetType().GetCustomAttribute(typeof(TableAttribute))).Name;
            var relevantProperties = obj.GetType().GetProperties().Where(x => !Attribute.IsDefined(x, typeof(ComputedAttribute))).ToList();
            for (int i = 0; i < relevantProperties.Count(); i++)
            {
                object val = null;
                var propertyInfo = relevantProperties[i];
                if (propertyInfo.PropertyType.IsEnum)
                {
                    val = Enum.GetName(propertyInfo.PropertyType, propertyInfo.GetValue(obj));
                }
                else
                {
                    val = propertyInfo.GetValue(obj);
                }
                propertyValuesMap.Add(propertyInfo.Name, val);
                var propName = i == relevantProperties.Count() - 1 ? $"{propertyInfo.Name}" : $"{propertyInfo.Name},";
                columns.Append(propName);
                values.Append($"@{propName}");
            }
            return sqlConnection.Execute($"Insert Into {tableName} ({columns}) values ({values})", propertyValuesMap);
        }
