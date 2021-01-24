    public KeyValuePair<string, string> CheckForNonNullArguments<T>() where T : class
    {
        System.Reflection.PropertyInfo[] properties = typeof(T).GetProperties();
        foreach (System.Reflection.PropertyInfo property in properties)
        {
            object val = property.GetValue(this, null);
            string str = val.ToString();
            if (val != null && (!str.Equals("NULL") && !str.Equals("0")) && !String.IsNullOrEmpty(str)
                return new KeyValuePair<string, string>(property.Name.ToString(), str);
        }
        return new KeyValuePair<string, string>(string.Empty, string.Empty);
        //if (property.GetValue(this, null) != null) GetName(() => property); ;
    }
