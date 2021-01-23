    public static class DateTimeSwitch
    {
        public static void DateTimeToSqlDateTime(this object obj)
        {
            Type objType = obj.GetType();
            if (typeof(IEnumerable).IsAssignableFrom(objType))
            {
                IEnumerable enumerable = (IEnumerable)obj;
                if (enumerable != null)
                {
                    foreach (object c in enumerable)
                    {
                        if (c != null)
                            c.DateTimeToSqlDateTime();
                    }
                }
            }
            else
            {
                PropertyInfo[] properties = objType.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (typeof(DateTime).IsAssignableFrom(property.PropertyType))
                    {
                        // Get the value, adjust it.
                        DateTime value = (DateTime)property.GetValue(obj, null);
                        if (value < (DateTime)SqlDateTime.MinValue)
                        {
                            property.SetValue(obj, (DateTime)SqlDateTime.MinValue, null);
                        }
                    }
                    else if (!property.PropertyType.IsPrimitive && typeof(String) != property.PropertyType && typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                    {
                        IEnumerable enumerable = (IEnumerable)property.GetValue(obj, null);
                        if (enumerable != null)
                        {
                            foreach (object c in enumerable)
                            {
                                if (c != null)
                                    c.DateTimeToSqlDateTime();
                            }
                        }
                    }
                    else if (!property.PropertyType.IsPrimitive)
                    {
                        if (property.PropertyType.Assembly == objType.Assembly)
                        {
                            var value = property.GetValue(obj, null);
                            if (value != null) value.DateTimeToSqlDateTime();
                        }
                    }
                }
            }
        }
    }
