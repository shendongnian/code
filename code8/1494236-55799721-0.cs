    public static T ConvertToObject<T>(string query) where T : class, new()
        {
            using (var conn = new SqlConnection(AutoConfig.ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(query) {Connection = conn};
                var rd = cmd.ExecuteReader();
                var mappedObject = new T();
                if (!rd.HasRows) return mappedObject;
                var accessor = TypeAccessor.Create(typeof(T));
                var members = accessor.GetMembers();
                if (!rd.Read()) return mappedObject;
                for (var i = 0; i < rd.FieldCount; i++)
                {
                    var columnNameFromDataTable = rd.GetName(i);
                    var columnValueFromDataTable = rd.GetValue(i);
                    var splits = columnNameFromDataTable.Split('_');
                    var columnName = new StringBuilder("");
                    foreach (var split in splits)
                    {
                        columnName.Append(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(split.ToLower()));
                    }
                    var mappedColumnName = members.FirstOrDefault(x =>
                        string.Equals(x.Name, columnName.ToString(), StringComparison.OrdinalIgnoreCase));
                    if(mappedColumnName == null) continue;
                    var columnType = mappedColumnName.Type;
                    if (columnValueFromDataTable != DBNull.Value)
                    {
                        accessor[mappedObject, columnName.ToString()] = Convert.ChangeType(columnValueFromDataTable, columnType);
                    }
                }
                return mappedObject;
            }
        }
