      public static List<T> ToList<T>(this DataTable dt) where T : new()
            {
            var returnList = new List<T>();
            var properties = new PropertyInfo[dt.Columns.Count];
            for (int i = 0; i < properties.Length; i++)
            {
                properties[i] = typeof(T).GetProperty(dt.Columns[i].Caption, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            }
            PropertyInfo property;
            foreach (DataRow dr in dt.Rows)
            {
                T resultItem = new T();
                for (int i = 0; i < properties.Length; i++)
                {
                    if ((property = properties[i]) == null)
                    {
                        continue;
                    }
                    if (!DBNull.Value.Equals((object)dr[i] ?? (object)DBNull.Value))
                    {
                        property.SetValue(resultItem, dr[i], null);
                    }
                }
                returnList.Add(resultItem);
            }
            return returnList;
        }
