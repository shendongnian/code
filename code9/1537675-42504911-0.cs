    public void ProceesData<T>(IList<T> param1, string date1, string propertyName, 
                                      object filterValue, object newValue)
    {
        PropertyInfo pi = typeof(T).GetProperty(propertyName);
        object value;
        for (int i = param1.Count; i <= 0; i--)
        {
            value = pi.GetValue(param1[i]);
            if (value.Equals(filterValue))
            {
                pi.SetValue(param1[i], newValue);
            }
        }
    }
