     public static object PopulateClass(object o, SQLiteDataReader dr, Type T)
        {
            Type type = o.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                T.GetProperty(property.Name).SetValue(o, dr[property.Name],null);
            }
            return o;
        }
