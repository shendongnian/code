    public static void ProceesData<T>(IList<T> param1, string date1, string propertyName, object filterValue, object newValue)
    {
        for (int i = param1.Count-1; i >= 0; i--)
        {
            PropertyInfo pi = param1[i].GetType().GetProperty(propertyName);
            object value;
            value = pi.GetValue(param1[i]);
            if (value.Equals(filterValue))
            {
                pi.SetValue(param1[i], newValue);
            }
        }
    }
